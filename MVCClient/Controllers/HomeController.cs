﻿using MVCClient.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TestApi()
        {
            ApiHelper helper = new ApiHelper();
            helper.TestWithClientCredentials();
            return View("Index");
        }

        public ActionResult Callback()
        {
            return View("Index");
        }
    }
}