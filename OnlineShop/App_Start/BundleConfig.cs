using System.Web;
using System.Web.Optimization;

namespace OnlineShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/jquery").Include(
                "~/Scripts/jquery-3.3.1.min.js",
                "~/Assets/Client/js/jquery-ui.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Assets/Client/js/move-top.js",
                "~/Assets/Client/js/easing.js",
                "~/Assets/Client/js/startstop-slider.js"));

            bundles.Add(new ScriptBundle("~/bundle/BaseController").Include(
                "~/Assets/Client/js/controller/BaseController.js"));

            bundles.Add(new ScriptBundle("~/bundle/Cart").Include(
                "~/Assets/Client/js/controller/CartController.js",
                "~/Assets/Client/js/controller/Cart.js"));

            bundles.Add(new ScriptBundle("~/bundle/Contact").Include(
                "~/Assets/Client/js/controller/ContactController.js",
                "~/Assets/Client/js/controller/GoogleMap.js"));

            bundles.Add(new ScriptBundle("~/bundle/User").Include(
                "~/Assets/Client/js/controller/UserController.js"));

            bundles.Add(new StyleBundle("~/bundle/css").Include(
                      "~/Assets/Client/bootstrap/css/bootstrap.css",
                      "~/Assets/Client/css/bootstrap-social.css",
                      "~/Assets/Client/bootstrap/css/font-awesome.min.css",
                      "~/Assets/Client/css/jquery-ui.css",
                      "~/Assets/Client/css/style.css",
                      "~/Assets/Client/css/slider.css"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
