using OnlineShop.Common;
using OnlineShop.Models.BLL;
using OnlineShop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Slides = SlideBLL.GetAllSlide();
            ViewBag.NewProducts = ProductBLL.GetNewProducts(4);
            ViewBag.FeatureProducts = ProductBLL.GetFeatureProducts(4);

            ViewBag.Title = ConfigurationManager.AppSettings["HomeTitle"];
            ViewBag.Keywords = ConfigurationManager.AppSettings["HomeKeyword"];
            ViewBag.Description = ConfigurationManager.AppSettings["HomeDescription"];
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public PartialViewResult MainMenu()
        {           
            return PartialView(MenuBLL.GetMenuByID(1));
        }

        [ChildActionOnly]
        public PartialViewResult MenuTop()
        {
            return PartialView(MenuBLL.GetMenuByID(2));
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var carts = Session[CommonConstants.CART_SESSION];
            List<CartItem> listCarts = carts != null ? carts as List<CartItem> : new List<CartItem>();
            return PartialView(listCarts);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public PartialViewResult Footer()
        {
            return PartialView(FooterBLL.GetFooter());
        }
    }
}