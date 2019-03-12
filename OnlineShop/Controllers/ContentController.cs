using OnlineShop.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index(int page = 1, int pageSize= 10)
        {
            var content = ContentBLL.ListAllPaging(page, pageSize);
            int totalRecord = 0;

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(content);
        }


        public ActionResult Detail(int ID)
        {
            var content = ContentBLL.GetContentByID(ID);
            ViewBag.Tags = TagBLL.GetAllTag(ID);
            return View(content);
        }

        public ActionResult Tag(string tagId, int page = 1, int pageSize = 10)
        {
            var model = ContentBLL.ListAllByTag(tagId, page, pageSize);
            int totalRecord = 0;

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            ViewBag.Tag = TagBLL.GetTag(tagId);
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
    }
}