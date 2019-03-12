using OnlineShop.Models.BLL;
using OnlineShop.Models.DTO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using OnlineShop.Common;
using Facebook;
using System.Configuration;
using System.Xml.Linq;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        // GET: User

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var result = UserBLL.CheckUser(loginDTO.UserName, Encryptor.MD5Hash(loginDTO.Password));
                if (result == 1)
                {
                    var user = UserBLL.GetUserByID(loginDTO.UserName);
                    Session[CommonConstants.USER_SESSION] = new UserLogin { UserID = user.ID, UserName = user.UserName };
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }
            return View(loginDTO);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [SimpleCaptchaValidation("CaptchaCode", "RegistrationCaptcha",
     "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                if (UserBLL.CheckUser(registerDTO.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (UserBLL.CheckEmail(registerDTO.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User
                    {
                        Name = registerDTO.Name,
                        UserName = registerDTO.UserName,
                        Password = Encryptor.MD5Hash(registerDTO.Password),
                        Address = registerDTO.Address,
                        Email = registerDTO.Email,
                        Phone = registerDTO.Phone,
                        ProvinceID = registerDTO.ProvinceID,
                        DistrictID = registerDTO.DistrictID,
                        Status = true
                    };
                    if (UserBLL.InsertUser(user) > 0)
                    {
                        return Login(new LoginDTO { UserName = registerDTO.UserName, Password = registerDTO.Password });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            return View(registerDTO);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult LoginFacebook()
        {
            var facebook = new FacebookClient();
            var loginUrl = facebook.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FacebookID"],
                client_secret = ConfigurationManager.AppSettings["FacebookSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return View(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var facebook = new FacebookClient();
            dynamic result = facebook.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FacebookID"],
                client_secret = ConfigurationManager.AppSettings["FacebookSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                facebook.AccessToken = accessToken;
                dynamic me = facebook.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstName = me.first_name;
                string middleName = me.middle_name;
                string lastName = me.last_name;

                var user = new User
                {
                    Email = email,
                    UserName = userName,
                    Name = firstName + " " + middleName + " " + lastName,
                    Status = true
                };

                var resultInsert = UserBLL.InsertForFacebook(user);
                if (resultInsert > 0)
                {
                    Session[CommonConstants.USER_SESSION] = new UserLogin { UserID = user.ID, UserName = user.UserName };
                }
            }
            return Redirect("/");
        }

        [HttpPost]
        public JsonResult LoadProvince()
        {
            var provinces = new List<ProvinceDTO>();
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Assets/Client/data/Provinces_Data.xml"));
            var xElement = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province").ToList();
            
            for (int i = 0; i < xElement.Count; i++)
            {
                provinces.Add(new ProvinceDTO
                {
                    ID = int.Parse(xElement[i].Attribute("id").Value),
                    Name = xElement[i].Attribute("value").Value
                });
            }
            return Json(new { data = provinces, status = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LoadDistrict(int provinceID)
        {
            var districts = new List<DistrictDTO>();
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Assets/Client/data/Provinces_Data.xml"));
            var xElement = xmlDoc.Element("Root").Elements("Item")
                .Where(x => (x.Attribute("type").Value == "province") && (int.Parse(x.Attribute("id").Value) == provinceID))
                .Elements("Item").Where(x => x.Attribute("type").Value == "district").ToList();

            for (int i = 0; i < xElement.Count; i++)
            {
                districts.Add(new DistrictDTO
                {
                    ID = int.Parse(xElement[i].Attribute("id").Value),
                    Name = xElement[i].Attribute("value").Value,
                    ProvinceID = int.Parse(xElement[i].Attribute("id").Value)
                });
            }
            return Json(new { data = districts, status = true }, JsonRequestBehavior.AllowGet);
        }
    }
}