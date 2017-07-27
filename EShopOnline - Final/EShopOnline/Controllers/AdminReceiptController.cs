using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace EShopOnline.Controllers
{
    public class AdminReceiptController : Controller
    {
        // GET: Receipt
        public ActionResult Index()
        {
            return RedirectToAction("Receipt");
        }
        //receipt
        #region
        public ActionResult Receipt(int page = 1)
        {
            Models.Receipt rec = new Models.Receipt();
            return View(rec.GetReceipt().ToPagedList(page,2));
        }
        [HttpGet]
        public ActionResult UpdateReceipt(int id)
        {
            Models.Receipt rec = new Models.Receipt();
            return View(rec.GetReceiptByID(id));
        }
        #endregion
        //receipt detail
        #region
        public ActionResult ReceiptDetail( int id,int page = 1)
        {
            Models.ReceiptDetail recdetail = new Models.ReceiptDetail();
            return View(recdetail.GetReceiptDetailByMaHD(id).ToPagedList(page,2));
        }
        [HttpGet]
        public ActionResult UpdateReceiptDetail(int id)
        {
            Models.ReceiptDetail rec = new Models.ReceiptDetail();
            return View(rec.GetReceiptDetailByMaSP(id));
        }
        #endregion
        public ActionResult Delivery()
        {
            return View();
        }
    }
}