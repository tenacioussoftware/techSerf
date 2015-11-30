using Nancy;
using techSerfWeb.Properties;

namespace techSerfWeb.Areas.Admin.Controllers
{
    public class TaskModule : NancyModule
    {
        public TaskModule() :
            base("/admin/tasks")
        {
            //Things to process before the route
            Before += ctx =>
            {
                //Grab any settings info and throw it into ViewBag
                Settings s = new Settings();
                ViewBag.ApplicationName = s.appName;
                ViewBag.ActivePath = "/admin/tasks";
                return null; //Return null to proceed, return HtmlResponse to abort request.
            };

            Get["/"] = parameters =>
            {
                return View["Tasks/index"];
            };
        }
    }
}
