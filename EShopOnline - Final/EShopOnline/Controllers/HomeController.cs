using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Models.Home home = new Models.Home();
            using (var context = new BanDoDienTuEntities())
            {
                var feature = from sp in context.SanPhams
                        join lsp in context.LoaiSanPhams on sp.MaLoai equals lsp.MaLoai
                        where lsp.TenLoai == "mới nhập"
                        select new Models.Product { MaSP = sp.MaSP, TenSP = sp.TenSP, DonGia = sp.GiaBan, Hinh = sp.Hinh };
                home.FeaturePhone = feature.Take(6).ToList();

                //đếm số lượng sản phẩm
                List<Models.BrandHome> li = new List<Models.BrandHome>();
                Models.Brand brand = new Models.Brand();
                List<Models.Brand> b = brand.GetBrand();
                foreach(Models.Brand item in b)
                {
                    Models.BrandHome brh = new Models.BrandHome();
                    brh.MaNSX = item.MaNSX;
                    brh.TenNSX = item.TenNSX;
                    var h = from sp in context.SanPhams
                            join nsx in context.NhaSanXuats on sp.MaNSX equals nsx.MaNSX
                            where nsx.TenNSX == item.TenNSX
                            select new Models.Product { };
                    brh.SoLuong = h.Count();
                    li.Add(brh);
                }
                home.brand = li;

                
            }
           
                return View(home);
        }
        public ActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}