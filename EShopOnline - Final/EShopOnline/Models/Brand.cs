using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class Brand
    {
        public int MaNSX { get; set; }
        public string TenNSX { get; set; }
        public List<Brand> GetBrand()
        {
            List<Models.Brand> brand;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from nsx in context.NhaSanXuats
                               select new Models.Brand
                               {
                                   MaNSX = nsx.MaNSX,
                                   TenNSX = nsx.TenNSX
                               };

                brand = L2EQuery.ToList();

            }
            return brand;
        }
        public Brand GetBrandByID(int id)
        {
            Brand brand;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from nsx in context.NhaSanXuats
                               where nsx.MaNSX == id
                               select new Models.Brand
                               {
                                   MaNSX = nsx.MaNSX,
                                   TenNSX = nsx.TenNSX
                               };

                brand = L2EQuery.SingleOrDefault();

            }
            return brand;
        }
        public Brand GetBrandByName(string name)
        {
            Brand brand;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from nsx in context.NhaSanXuats
                               where nsx.TenNSX == name
                               select new Models.Brand
                               {
                                   MaNSX = nsx.MaNSX,
                                   TenNSX = nsx.TenNSX
                               };

                brand = L2EQuery.SingleOrDefault();

            }
            return brand;
        }
    }
}