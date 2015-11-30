﻿using Nancy;
using techSerfWeb.Properties;

namespace techSerfWeb.Areas.Admin.Controllers
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
                ViewBag.ActivePath = "/admin";
                return null; //Return null to proceed, return HtmlResponse to abort request.
            };

            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }


    }
}
