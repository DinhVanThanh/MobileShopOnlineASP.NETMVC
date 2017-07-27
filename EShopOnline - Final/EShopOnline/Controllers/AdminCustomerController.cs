using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopOnline.Controllers
{
    public class AdminCustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return RedirectToAction("CustomerProfile");
        }
        public ActionResult CustomerProfile()
        {
            
            return View();
        }
        public JsonResult CustomerList()
        {
            Models.Customer listcustomer = new Models.Customer();

            return Json(listcustomer.GetCustomer());
        }
        [HttpPost]
        public int DeleteCustomer(int MaKH)
        {
            int success = 0;
            using (var context = new BanDoDienTuEntities())
            {
                KhachHang deletecustomer = context.KhachHangs.Where(makh => makh.MaKH == MaKH).FirstOrDefault();
                if (deletecustomer != null)
                {
                    context.KhachHangs.Remove(deletecustomer);
                    success = context.SaveChanges();
                }

            }
            return success;

        }
        [HttpPost]
        public int UpdateCustomer(List<listcustomer> kh)
        {
            int success = 0;
            using (var context = new BanDoDienTuEntities())
            {
                foreach(listcustomer item in kh)
                {
                    KhachHang updatecustomer = context.KhachHangs.Where(makh => makh.MaKH == item.recid).First();
                    if (updatecustomer != null)
                    {
                        if(item.TenKH != null)
                            updatecustomer.TenKH = item.TenKH;
                        if (item.SDT != null)
                            updatecustomer.SDT = item.SDT;
                        if (item.DiaChi != null)
                            updatecustomer.DiaChi = item.DiaChi;
                        if (item.Email != null)
                            updatecustomer.Email = item.Email;
                        context.Entry(updatecustomer).State = System.Data.Entity.EntityState.Modified;
                        success = context.SaveChanges();
                    }
                }
               

            }
            return success;
        }
        public class listcustomer
        {
            public int recid { get; set; }
            public string TenKH { get; set; }
            public string SDT { get; set; }
            public string DiaChi { get; set; }
            public string Email { get; set; }
        }
    }
}