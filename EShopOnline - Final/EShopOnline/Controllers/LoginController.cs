using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUpForm()
        {
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("cusname");
            HttpContext.Session.Remove("cuscode");
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            using (var context = new BanDoDienTuEntities())
            {
                Models.USER a = new Models.USER();
                Models.USER us = a.GetUser(form["username"].ToString(), form["password"].ToString());
                if(us != null )
                {
                    if(us.ChucNang.Contains("admin"))
                    {
                        return RedirectToAction("Index", "AdminHome");
                    }
                    else if(us.ChucNang.Contains("customer"))
                    {
                        
                        if(HttpContext.Session["cart"] == null)
                            HttpContext.Session["cart"] = new List<Models.Cart>();
                        HttpContext.Session["cusname"] = us.TenKH;
                        HttpContext.Session["cuscode"] = us.MaKH;
                        return RedirectToAction("Index","Home");
                        
                    }
                }
            }
            return RedirectToAction("Login","Home");
           
        }
        [HttpPost]
        public ActionResult Signup(FormCollection form)
        {
            using (var context = new BanDoDienTuEntities())
            {
                User user = new User();
                user.MaPQ = 2;
                user.Username = form["email"].ToString();
                user.Password = form["pass"].ToString();
                context.Users.Add(user);

                context.SaveChanges();

            }
            using (var context = new BanDoDienTuEntities())
            {
                var a = from u in context.Users
                        select new Models.USER { MaTK = u.MaTK};
                Models.USER us = a.OrderByDescending(matk => matk.MaTK).FirstOrDefault();
                KhachHang kh = new KhachHang();
                kh.TenKH = form["name"].ToString();
                kh.SDT = form["phone"].ToString();
                kh.DiaChi = form["address"].ToString();
                kh.Email = form["email"].ToString();
                kh.MaTK = us.MaTK;
                context.KhachHangs.Add(kh);

                context.SaveChanges();
            }
                return View("Index");
        }
    }
}