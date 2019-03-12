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
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            var contents = ContentBLL.GetAllContent();
            return View(contents);
        }

        public void SetViewBag(int? selectedID = null)
        {
            var category = CategoryBLL.GetAllCategory();
            ViewBag.Category = new SelectList(category, "ID", "Name", selectedID);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ContentModel contentModel)
        {
            if (ModelState.IsValid)
            {
                var session = Session[Common.CommonConstants.USER_SESSION] as UserLogin;
                contentModel.CreatedBy = session.UserName;
                var culture = Session[CommonConstants.CURRENT_CULTURE];
                contentModel.Language = culture.ToString();
                var content = new Content
                {
                    ID = contentModel.ID,
                    Name = contentModel.Name,
                    MetaTitle = contentModel.MetaTitle,
                    Description = contentModel.Description,
                    Image = contentModel.Image,
                    CategoryID = contentModel.CategoryID,
                    Detail = HttpUtility.HtmlEncode(contentModel.Detail),
                    Warrantly = contentModel.Warrantly,
                    CreatedBy = contentModel.CreatedBy,
                    MetaKeywords = contentModel.MetaKeywords,
                    MetaDescriptions = contentModel.MetaDescriptions,
                    Status = contentModel.Status,
                    Tags = contentModel.Tags,
                };
                var result = ContentBLL.InsertContent(content);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nội dung tin tức không thành công");
                }
            }
            SetViewBag();
            return View(contentModel);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var result = ContentBLL.GetContentByID(ID);
            SetViewBag(result.CategoryID);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ContentModel contentModel)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag(contentModel.CategoryID);
            return View(contentModel);
        }
    }
}