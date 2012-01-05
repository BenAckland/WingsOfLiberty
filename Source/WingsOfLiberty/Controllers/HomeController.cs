using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WingsOfLiberty.Infrastructure.Logging;

namespace WingsOfLiberty.Controllers
{
    public class HomeController : Controller
    {
        INLogger logger;

        public HomeController(INLogger logger)
        {
            this.logger = logger;
        }
        public ActionResult Index()
        {
            logger.LogInfo("Called the home page");

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
