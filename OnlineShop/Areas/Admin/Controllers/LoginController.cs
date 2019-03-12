using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using OnlineShop.Models.BLL;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = UserBLL.CheckUser(loginModel.UserName, Encryptor.MD5Hash(loginModel.Password), true);
                var credentials = UserBLL.GetListCredential(loginModel.UserName);
                if (result == 1)
                {
                    var user = UserBLL.GetUserByID(loginModel.UserName);
                    Session[CommonConstants.SESSION_CREDENTIALS] = credentials;
                    Session[CommonConstants.USER_SESSION] = new UserLogin { UserID = user.ID, UserName = user.UserName, UserGroupID = user.UserGroupID };
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Index");
        }
    }
}