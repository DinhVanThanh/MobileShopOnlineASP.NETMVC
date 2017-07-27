using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class TypeOfProduct
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public List<TypeOfProduct> GetTypeOfProduct()
        {
            List<Models.TypeOfProduct> TypeOfProduct;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from lsp in context.LoaiSanPhams
                               select new Models.TypeOfProduct
                               {
                                   MaLoai = lsp.MaLoai,
                                   TenLoai = lsp.TenLoai
                               };

                TypeOfProduct = L2EQuery.ToList();

            }
            return TypeOfProduct;
        }
        public TypeOfProduct GetTypeOfProductByName(string name)
        {
            TypeOfProduct a;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from lsp in context.LoaiSanPhams
                               where lsp.TenLoai == name
                               select new Models.TypeOfProduct
                               {
                                   MaLoai = lsp.MaLoai,
                                   TenLoai = lsp.TenLoai
                               };

                a = L2EQuery.SingleOrDefault();

            }
            return a;
        }
        public TypeOfProduct GetTypeOfProductByID(int id)
        {
            TypeOfProduct a;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from lsp in context.LoaiSanPhams
                               where lsp.MaLoai == id
                               select new Models.TypeOfProduct
                               {
                                   MaLoai = lsp.MaLoai,
                                   TenLoai = lsp.TenLoai
                               };

                a = L2EQuery.SingleOrDefault();

            }
            return a;
        }
    }
}