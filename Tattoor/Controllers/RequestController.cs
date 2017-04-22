using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tattoor.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Artist(string id)
        {
            return View();
        }
    }
}