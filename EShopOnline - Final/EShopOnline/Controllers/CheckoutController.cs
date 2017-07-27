using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopOnline.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            using (var context = new BanDoDienTuEntities())
            {
                long? tongtien = 0;
                HoaDon hd = new HoaDon();
                List<Models.Cart> licart = HttpContext.Session["cart"] as List<Models.Cart>;
                foreach(Models.Cart item in licart)
                {
                    tongtien += item.TongTien;
                }
                hd.MaKH = int.Parse(HttpContext.Session["cuscode"].ToString());
                hd.NgayLap = DateTime.Today;
                hd.TongTien = tongtien;
                hd.TinhTrangDonHang = "chưa giao";
                context.HoaDons.Add(hd);
                context.SaveChanges();
            }
            using (var context = new BanDoDienTuEntities())
            {
                var a = from hd in context.HoaDons
                        select new Models.Receipt { MaHD = hd.MaHD };
                
                int MAHD = a.ToList().OrderByDescending(mahd => mahd.MaHD).FirstOrDefault().MaHD;
                List<Models.Cart> licart = HttpContext.Session["cart"] as List<Models.Cart>;
                foreach (Models.Cart item in licart)
                {
                    ChiTietHoaDon cthd = new ChiTietHoaDon();
                    cthd.MaHD = MAHD;
                    cthd.MaSP = item.MaSP;
                    cthd.SoLuong = item.SoLuong;
                    cthd.TongTien = item.TongTien;
                    context.ChiTietHoaDons.Add(cthd);
                    context.SaveChanges();
                }
               
            }
            HttpContext.Session["cart"] = new List<Models.Cart>();
            return View("Index");
        }
    }
}