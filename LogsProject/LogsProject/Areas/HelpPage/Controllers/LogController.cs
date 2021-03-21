using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogsProject.Areas.HelpPage.Controllers
{
    public class LogController : Controller
    {
        // GET: HelpPage/Log
        public ActionResult Index()
        {
            return View();
        }
    }
}