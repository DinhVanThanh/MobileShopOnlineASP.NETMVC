using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopOnline.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<Models.Cart> cart = HttpContext.Session["cart"] as List<Models.Cart>;
            if (cart == null)
                cart = null;
            return View(cart);
        }
        
        public string AddToCart(int id)
        {
            Models.Cart pro;
            using (var context = new BanDoDienTuEntities())
            {
                var a = from sp in context.SanPhams
                        where sp.MaSP == id
                        select new Models.Cart {Hinh = sp.Hinh, MaSP = id, TenSP = sp.TenSP, DonGia = sp.GiaBan, SoLuong = 1, TongTien = sp.GiaBan };
                pro = a.SingleOrDefault();
            }
            if (pro != null)
            {
                List<Models.Cart> licart = HttpContext.Session["cart"] as List<Models.Cart>;
                if(licart != null)
                {
                    licart.Add(pro);
                    HttpContext.Session["cart"] = licart;
                    return "success";
                }
                else
                    return "login";
            }
            else
                return "fail";
        }
        public string DeleteCart(int id)
        {
            List<Models.Cart> licart = HttpContext.Session["cart"] as List<Models.Cart>;
            licart.Remove(licart.SingleOrDefault(s => s.MaSP == id));
            HttpContext.Session["cart"] = licart;
            return "success";
        }
    }
}