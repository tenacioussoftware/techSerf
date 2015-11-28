using Nancy;
using techSerfWeb.Properties;

namespace techSerfWeb.Controllers
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            //Things to process before the route
            Before += ctx =>
            {
                //Grab any settings info and throw it into ViewBag
                Settings s = new Settings();
                ViewBag.ApplicationName = s.appName;
                return null; //Return null to proceed, return HtmlResponse to abort request.
            };

            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Get["/about"] = parameters =>
            {
                return View["about"];
            };
        }


    }
}