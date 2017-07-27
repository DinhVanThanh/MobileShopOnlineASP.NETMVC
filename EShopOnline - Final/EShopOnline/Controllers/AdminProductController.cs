using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace EShopOnline.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return RedirectToAction("Product");
        }
        //import product
        #region 
        public ActionResult ImportProduct(int page  = 1)
        {
            Models.ImportProduct product = new Models.ImportProduct();
            return View(product.GetImportProduct().ToPagedList(page, 2));
        }
        [HttpPost]
        public JsonResult GetImportProductList()
        {
            Models.ImportProduct importproduct = new Models.ImportProduct();
            return Json(importproduct.GetImportProduct());
        }
        
        public ActionResult AddImportProduct()
        {
            Models.Product pro = new Models.Product();
            return View(pro.GetProduct());
        }
        [HttpPost]
        public ActionResult AddImportProdutcToDatabase(FormCollection form)
        {
            using (var context = new BanDoDienTuEntities())
            {
                NhapSanPham nsp = new NhapSanPham();
                nsp.MaSP = int.Parse(form["SanPham"].ToString());
                nsp.SoLuong = int.Parse(form["SoLuong"].ToString());
                nsp.DonGia = int.Parse(form["DonGia"].ToString());
                nsp.NgayNhap = DateTime.Parse(form["NgayNhap"].ToString());
                nsp.GhiChu = form["Ghichu"].ToString();
                nsp.TongTien = int.Parse(form["SoLuong"].ToString()) * int.Parse(form["DonGia"].ToString());
                context.NhapSanPhams.Add(nsp);

                
                SanPham pro = context.SanPhams.ToList<SanPham>().Where(masp => masp.MaSP == int.Parse(form["SanPham"].ToString())).FirstOrDefault<SanPham>();
                pro.SoLuongTrongKho += int.Parse(form["SoLuong"].ToString());

                context.SaveChanges();
            }
                return RedirectToAction("ImportProduct");
        }
        [HttpGet]
        public ActionResult  UpdateImportProductList(int id = 1)
        {
            Models.ImportProduct importproduct = new Models.ImportProduct();
            
            return View(importproduct.GetImportProductByID(id));
        }
        [HttpPost]
        public int DeleteImportProduct(int id)
        {
            int success = 0;
            using (var context = new BanDoDienTuEntities())
            {
                NhapSanPham deleteimportproduct = context.NhapSanPhams.Where(mansp => mansp.MaNhap == id).FirstOrDefault();
                if (deleteimportproduct != null)
                {
                    context.NhapSanPhams.Remove(deleteimportproduct);
                    success = context.SaveChanges();
                }

            }
            return success;
        }
        #endregion
        //product
        #region
        [HttpGet]
        public ActionResult Product(int page = 1)
        {
            Models.Product product = new Models.Product();
            return View(product.GetProduct().ToPagedList(page,3));
        }
        public JsonResult GetProductList()
        {
            Models.Product product = new Models.Product();
            return Json(product.GetProduct());
        }
        public JsonResult GetTypeOfProductList()
        {
            Models.TypeOfProduct Typelist = new Models.TypeOfProduct();
            return Json(Typelist.GetTypeOfProduct());
        }
        [HttpGet]
        public ActionResult UpdateProductList(int id = 1)
        {
            Models.Product product = new Models.Product();
            return View(product.GetProductByID(id));
        }
        #endregion
        //type of product
        #region
        public ActionResult TypeOfProduct(int page = 1)
        {
            Models.TypeOfProduct listtype = new Models.TypeOfProduct();
            return View(listtype.GetTypeOfProduct().ToPagedList(page,2));
        }
        public ActionResult UpdateTypeOfProduct(int id)
        {
            Models.TypeOfProduct updatetype = new Models.TypeOfProduct();
            return View(updatetype.GetTypeOfProductByID(id));
        }
        #endregion
        //brand
        #region
        public ActionResult Brand(int page = 1)
        {
            Models.Brand listbrand = new Models.Brand();
            return View(listbrand.GetBrand().ToPagedList(page,2));
        }
        public ActionResult UpdateBrand(int id)
        {
            Models.Brand updatebrand = new Models.Brand();
            return View(updatebrand.GetBrandByID(id));
        }
        #endregion
        
    }
}