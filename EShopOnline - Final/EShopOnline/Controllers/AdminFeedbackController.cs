using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace EShopOnline.Controllers
{
    public class AdminFeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            return RedirectToAction("Feedback");
        }
        public ActionResult Feedback(int page = 1)
        {
            Models.Feedback feedback = new Models.Feedback();
            return View(feedback.GetFeedbackList().ToPagedList(page,2));
        }
    }
}