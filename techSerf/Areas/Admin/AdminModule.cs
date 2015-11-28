using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using techSerfWeb.Properties;

namespace techSerfWeb.Areas.Admin
{
    public class AdminModule: NancyModule
    {
        public AdminModule()
            : base ("/admin")
        {
            //Things to process before the route
            Before += ctx =>
            {
                //Grab any settings info and throw it into ViewBag
                Settings s = new Settings();
                ViewBag.ApplicationName = s.appName;
                ViewBag.ViewBase = "Areas/Admin/Views/";
                return null; //Return null to proceed, return HtmlResponse to abort request.
            };

            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }


    }
}
