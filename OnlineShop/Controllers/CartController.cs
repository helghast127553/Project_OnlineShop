using OnlineShop.Common;
using OnlineShop.Models.BLL;
using OnlineShop.Models.DTO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Card
        public List<CartItem> Cart()
        {
            var carts = Session[CommonConstants.CART_SESSION] as List<CartItem>;
            var productsCart = new List<CartItem>();
            if (carts != null)
            {
                productsCart = carts as List<CartItem>;
            }
            return productsCart;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var cart = Cart();
            return View(cart);
        }

        [HttpGet]
        public ActionResult AddProductIntoCart(int productID, int quantity)
        {
            var cart = Session[CommonConstants.CART_SESSION];
            if (cart != null)
            {
                var listCarts = cart as List<CartItem>;
                var product = listCarts.Find(x => x.ProductID == productID);
                if (product != null)
                {
                    product.Quantity += quantity;
                }
                else
                {
                    listCarts.Add(new CartItem (productID, quantity));
                }
            }
            else
            {
                var listCarts = new List<CartItem>()
                {
                    new CartItem (productID, quantity)
                };
                Session[CommonConstants.CART_SESSION] = listCarts;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult UpdateProduct(int productID, int quantity)
        {
            var cartList = Session[CommonConstants.CART_SESSION] as List<CartItem>;
            var product = cartList.Find(x => x.ProductID == productID);
            if (product != null)
            {
                product.Quantity = quantity;
            }
            return Json(new { Total = product.Total.ToString("N0") },
                JsonRequestBehavior.AllowGet);
        }

       [HttpGet]
       public ActionResult DeleteProduct(int productID)
        {
            var cartList = Session[CommonConstants.CART_SESSION] as List<CartItem>;
            cartList.RemoveAll(x => x.ProductID == productID);
            if (cartList.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Payment()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    decimal total = 0;
                    int result = 0;

                    if (Session[CommonConstants.USER_SESSION] == null)
                    {
                        return Redirect("/dang-nhap");
                    }
                    var userLogin = Session[CommonConstants.USER_SESSION] as UserLogin;
                    var user = UserBLL.GetUserByID(userLogin.UserName);                   
                    var order = new Order
                    {
                        ShipName = user.Name,
                        ShipMobile = user.Phone,
                        ShipAddress = user.Address,
                        ShipEmail = user.Email
                    };
                    OrderBLL.InsertOrder(order);
                    var cart = Session[CommonConstants.CART_SESSION] as List<CartItem>;
                    for (int i = 0; i < cart.Count; i++)
                    {
                        var orderDetails = new OrderDetail
                        {
                            ProductID = cart[i].ProductID,
                            OrderID = order.ID,
                            Quantity = cart[i].Quantity,
                            Price = cart[i].Price
                        };
                        result = OrderDetailsBLL.InsertOrderDetails(orderDetails);
                        total += (cart[i].Price * cart[i].Quantity);
                    }
                    if (result > 0)
                    {
                        Session[CommonConstants.USER_SESSION] = null;
                        //string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/NewOrder.html"));
                        //content = content.Replace("{{CustomerName}}", user.Name);
                        //content = content.Replace("{{Phone}}", user.Phone);
                        //content = content.Replace("{{Email}}", user.Email);
                        //content = content.Replace("{{Address}}", user.Address);
                        //content = content.Replace("{{Total}}", total.ToString("N0"));
                        //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                        //var mailHelper = new MailHelper();
                        //mailHelper.SendEmail(user.Email, "Đơn hàng mới từ OnlineShop", content);
                        //mailHelper.SendEmail(toEmail, "Đơn hàng mới từ OnlineShop", content);
                    }                
                }
                catch (Exception ex)
                {
                    throw;
                }               
                return Redirect("/hoan-thanh");
            }
            ViewBag.Cart = Cart();

            return View();
        }
    }
}