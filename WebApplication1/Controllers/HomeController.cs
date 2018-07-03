using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

        public ActionResult ReadNews()
        {
            var client = new RestClient();
            var news = new News();

            client.BaseUrl = new Uri("http://localhost:50412/crawlerapi/Crawler/ExtractNews");

           
            return View();
        }

    }
}