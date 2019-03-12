using OnlineShop.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ProductCategory()
        {
            var productCategories = ProductCategoryBLL.GetAllProductCategory();
            return PartialView(productCategories);
        }

        public ActionResult Category(int ID, int page = 1, int pageSize = 8)
        {
            int totalRecord = 0;
            int maxPage = 5;
            int totalPage = 0;
          
            var productCategory = ProductCategoryBLL.GetProductDetail(ID);
            ViewBag.ProductCategory = productCategory;
            var products = ProductBLL.GetProductByCategoryID(ID, ref totalRecord, page, pageSize);
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            
            return View(products);
        }

        [HttpGet]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult ProductDetail(int ID)
        {
            var product = ProductBLL.GetProductDetail(ID);
            ViewBag.Category = ProductCategoryBLL.GetProductDetail(product.CategoryID.Value);
            ViewBag.RelatedProducts = ProductBLL.GetAllRelatedProduct(ID);
            return View(product);
        }

        [HttpGet]
        public JsonResult ListName(string keyword)
        {
            var products = ProductBLL.SearchProduct(keyword);
            return Json(new { data = products }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Search(string keyword, int page = 1, int pageSize = 8)
        {
            int totalRecord = 0;
            int maxPage = 5;
            int totalPage = 0;

            var products = ProductBLL.SearchProduct(keyword, ref totalRecord, page, pageSize);
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.Keyword = keyword;
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(products);
        }
    }
}