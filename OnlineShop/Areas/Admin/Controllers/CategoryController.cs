using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models.BLL;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    ID = categoryModel.ID,
                    Name = categoryModel.Name,
                    MetaTitle = categoryModel.MetaTitle,
                    ParentID = categoryModel.ParentID,
                    DisplayOrder = categoryModel.DisplayOrder,
                    SeoTitle = categoryModel.SeoTitle,
                    CreatedBy = categoryModel.CreatedBy,
                    ModifieldDate = categoryModel.ModifieldDate,
                    ModifiedBy = categoryModel.ModifiedBy,
                    MetaKeywords = categoryModel.MetaKeywords,
                    MetaDescriptions = categoryModel.MetaDescriptions,
                    Status = categoryModel.Status,
                    ShowOnHome = categoryModel.ShowOnHome,
                    Language = categoryModel.Language
                };
                var result = CategoryBLL.InsertCategory(category);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", StaticResources.Resources.InsertCategoryFailed);
                }
            }
            return View(categoryModel);
        }
    }
}