using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopOnline.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            Models.ProductDetail prode = new Models.ProductDetail(); 
           
            return View(prode.GetProductDetailByid(id));
        }
    }
}