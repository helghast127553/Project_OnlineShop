using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models.BLL;
using OnlineShop.Models.DTO;
using OnlineShop.Models.EF;

namespace OnlineShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var contact = ContactBLL.GetActiveContact();
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public JsonResult Send(FeedBackDTO feedbackDTO)
        {
            var feedback = new FeedBack
            {
               Name = feedbackDTO.Name,
               Email = feedbackDTO.Email,
               Phone = feedbackDTO.Phone,
               Content = HttpUtility.HtmlEncode(feedbackDTO.Content),
               Address = feedbackDTO.Address
            };
            var result = FeedBackBLL.InsertFeedback(feedback);
            return result > 0 ? Json(new { status = true }, JsonRequestBehavior.AllowGet) : 
                Json(new { status = false }, JsonRequestBehavior.AllowGet);
        }
    }
}