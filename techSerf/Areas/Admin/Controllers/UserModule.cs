using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using techSerfWeb.Properties;

namespace techSerfWeb.Areas.Admin.Controllers
{
    public class UserModule : NancyModule
    {
        public UserModule() : 
            base("/admin/users")
        {
            //Things to process before the route
            Before += ctx =>
            {
                //Grab any settings info and throw it into ViewBag
                Settings s = new Settings();
                ViewBag.ApplicationName = s.appName;
                ViewBag.ActivePath = "/admin/users";
                return null; //Return null to proceed, return HtmlResponse to abort request.
            };

            Get["/"] = parameters =>
            {
                return View["Users/index"];
            };
        }
    }
}
