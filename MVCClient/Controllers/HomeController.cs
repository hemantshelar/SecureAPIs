using IdentityModel.Client;
using MVCClient.Helper;
using MyCorp.Framework;
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

        public ActionResult TestAPIAuthorizationCode()
        {
            ApiHelper helper = new ApiHelper();
            helper.TestWithAuthorizationCode();
            return View();
        }

        public ActionResult Callback()
        {
            string code = Request.QueryString["code"] as string;
            string code1 = Request.QueryString["code1"] as string;
            var state = Request.QueryString["state"] as string;

            TokenClient token = new TokenClient("http://mycorpidentityserverapp.azurewebsites.net/identity/connect/token",
                "mymvcclient_authrorization_code", Constants.MyCorpMvcAppSecret);
            var result = token.RequestAuthorizationCodeAsync(code, "http://mvcclientdemo.azurewebsites.net/home/callback").Result;

            //HttpContext
            HttpCookie cookie = new HttpCookie("AuthAuthorizationCodeAccessKey", result.AccessToken);
            Response.Cookies.Add(cookie);

            return Redirect(state);
        }
    }
}