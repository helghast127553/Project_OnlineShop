using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Threading;
using System.Globalization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session[CommonConstants.CURRENT_CULTURE] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session[CommonConstants.CURRENT_CULTURE].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session[CommonConstants.CURRENT_CULTURE].ToString());
            }
            else
            {
                Session[CommonConstants.CURRENT_CULTURE] = "vi";
                Thread.CurrentThread.CurrentCulture = new CultureInfo("vi");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi"); 
            }
        }

        public ActionResult ChangeCulture(string ddlCulture, string returnURL)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);
            Session[CommonConstants.CURRENT_CULTURE] = ddlCulture;
            return Redirect(returnURL);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session[CommonConstants.USER_SESSION] as UserLogin;
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}