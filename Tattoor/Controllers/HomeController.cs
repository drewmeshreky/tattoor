using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tattoor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MenuItmes = new Dictionary<string, string>
            {
                ["Home"] = "#intro",
                ["About"] = "#about",
                ["Services"] = "#services",
                ["Portfolio"] = "#portfolio",
                ["Text"] = "#text",
                ["Team"] = "#team",
                ["Contact"] = "#contact",
            };
            return View();
        }
    }
}