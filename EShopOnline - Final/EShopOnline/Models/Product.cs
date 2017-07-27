using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class Product
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaLoai { get; set; }
        public int? SoLuongTrongKho { get; set; }
        public long? DonGia { get; set; }
        public string MaNSX { get; set; }
        public string TinhTrang { get; set; }
        public string NoiDung { get; set; }
        public string Hinh { get; set; }
        public List<Product> GetProduct()
        {

            List<Product> Product;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from sp in context.SanPhams
                               join lsp in context.LoaiSanPhams on sp.MaLoai equals lsp.MaLoai
                               join nsx in context.NhaSanXuats on sp.MaNSX equals nsx.MaNSX
                               select new Product
                               {
                                   MaSP = sp.MaSP,
                                   TenSP = sp.TenSP,
                                   MaLoai = lsp.TenLoai,
                                   SoLuongTrongKho = sp.SoLuongTrongKho,
                                   MaNSX = nsx.TenNSX,
                                   DonGia = sp.GiaBan,
                                   TinhTrang = sp.TinhTrang,
                                   NoiDung = sp.NoiDung,
                                   Hinh = sp.Hinh
                               };

                Product = L2EQuery.ToList();

            }
            return Product;

        }
        public List<Product> SearchProduct(string name)
        {

            List<Product> Product;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from sp in context.SanPhams
                               join lsp in context.LoaiSanPhams on sp.MaLoai equals lsp.MaLoai
                               join nsx in context.NhaSanXuats on sp.MaNSX equals nsx.MaNSX
                               where sp.TenSP.Contains(name) || nsx.TenNSX.Contains(name)
                               select new Product
                               {
                                   MaSP = sp.MaSP,
                                   TenSP = sp.TenSP,
                                   MaLoai = lsp.TenLoai,
                                   SoLuongTrongKho = sp.SoLuongTrongKho,
                                   MaNSX = nsx.TenNSX,
                                   DonGia = sp.GiaBan,
                                   TinhTrang = sp.TinhTrang,
                                   NoiDung = sp.NoiDung,
                                   Hinh = sp.Hinh
                               };

                Product = L2EQuery.ToList();

            }
            return Product;

        }
        public Product GetProductByID(int id)
        {

            Product product;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from sp in context.SanPhams
                               join lsp in context.LoaiSanPhams on sp.MaLoai equals lsp.MaLoai
                               join nsx in context.NhaSanXuats on sp.MaNSX equals nsx.MaNSX
                               where sp.MaSP == id
                               select new Product
                               {
                                   MaSP = sp.MaSP,
                                   TenSP = sp.TenSP,
                                   MaLoai = lsp.TenLoai,
                                   SoLuongTrongKho = sp.SoLuongTrongKho,
                                   MaNSX = nsx.TenNSX,
                                   TinhTrang = sp.TinhTrang,
                                   NoiDung = sp.NoiDung,
                                   Hinh = sp.Hinh,
                                   DonGia = sp.GiaBan
                               };

                product = L2EQuery.SingleOrDefault();

            }
            return product;

        }
        public List<Product> GetProductByBrand(string name)
        {

            List<Product> Product;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from sp in context.SanPhams
                               join lsp in context.LoaiSanPhams on sp.MaLoai equals lsp.MaLoai
                               join nsx in context.NhaSanXuats on sp.MaNSX equals nsx.MaNSX
                               where nsx.TenNSX.Contains(name)
                               select new Product
                               {
                                   MaSP = sp.MaSP,
                                   TenSP = sp.TenSP,
                                   MaLoai = lsp.TenLoai,
                                   SoLuongTrongKho = sp.SoLuongTrongKho,
                                   MaNSX = nsx.TenNSX,
                                   TinhTrang = sp.TinhTrang,
                                   NoiDung = sp.NoiDung,
                                   Hinh = sp.Hinh,
                                   DonGia = sp.GiaBan
                               };

                Product = L2EQuery.ToList();

            }
            return Product;

        }
        public List<Product> GetProductByCategoryAndBrand(string catename, string brand)
        {

            List<Product> Product;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from sp in context.SanPhams
                               join lsp in context.LoaiSanPhams on sp.MaLoai equals lsp.MaLoai
                               join nsx in context.NhaSanXuats on sp.MaNSX equals nsx.MaNSX
                               where lsp.TenLoai.Contains(catename) && nsx.TenNSX.Contains(brand)
                               select new Product
                               {
                                   MaSP = sp.MaSP,
                                   TenSP = sp.TenSP,
                                   MaLoai = lsp.TenLoai,
                                   SoLuongTrongKho = sp.SoLuongTrongKho,
                                   MaNSX = nsx.TenNSX,
                                   TinhTrang = sp.TinhTrang,
                                   NoiDung = sp.NoiDung,
                                   Hinh = sp.Hinh,
                                   DonGia = sp.GiaBan
                               };

                Product = L2EQuery.ToList();

            }
            return Product;

        }
        public List<Product> GetProductByBrand(int brandid)
        {

            List<Product> Product;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from sp in context.SanPhams
                               join lsp in context.LoaiSanPhams on sp.MaLoai equals lsp.MaLoai
                               join nsx in context.NhaSanXuats on sp.MaNSX equals nsx.MaNSX
                               where nsx.MaNSX == brandid
                               select new Product
                               {
                                   MaSP = sp.MaSP,
                                   TenSP = sp.TenSP,
                                   MaLoai = lsp.TenLoai,
                                   SoLuongTrongKho = sp.SoLuongTrongKho,
                                   MaNSX = nsx.TenNSX,
                                   TinhTrang = sp.TinhTrang,
                                   NoiDung = sp.NoiDung,
                                   Hinh = sp.Hinh,
                                   DonGia = sp.GiaBan
                               };

                Product = L2EQuery.ToList();

            }
            return Product;

        }
    }
}