using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult http404()
        {
            return View();
        }
        public ActionResult http405()
        {
            return View();
        }
        public ActionResult general()
        {
            return View();
        }
    }
}
