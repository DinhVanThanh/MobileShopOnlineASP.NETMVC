using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopOnline.Controllers
{
    public class AdminReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return RedirectToAction("DataTable", "AdminReport");
        }
        public ActionResult DataTable()
        {
            return View();
        }
        public ActionResult Chart()
        {
            return View();
        }
    }
}