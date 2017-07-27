using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace EShopOnline.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string name,int page = 1)
        {
            ViewBag.Brand = name;
            Models.Product pro = new Models.Product();
            return View(pro.GetProductByBrand(name).ToPagedList(page,6));
        }
        public ActionResult Product(string loai, string brand ,int page = 1)
        {
            ViewBag.Brand = brand;
            Models.Product pro = new Models.Product();
            return View("Index", pro.GetProductByCategoryAndBrand(loai, brand).ToPagedList(page,6));
        }
        [HttpGet]
        public ActionResult Search(string name, int page = 1)
        {
            Models.Product pro = new Models.Product();
            return View("Index", pro.SearchProduct(name).ToPagedList(page,6));
        }
    }
}