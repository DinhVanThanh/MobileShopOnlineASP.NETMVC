using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class ImportProduct
    {
        public int MaNhap { get; set; }
        public string TenSP { get; set; }
        public int? SoLuong { get; set; }
        public long? DonGia { get; set; }
        public DateTime? NgayNhap { get; set; }
        public long? TongTien { get; set; }
        public string GhiChu { get; set; }
        public List<ImportProduct> GetImportProduct()
        {
            List<Models.ImportProduct> customer;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from ip in context.NhapSanPhams
                               join sp in context.SanPhams on ip.MaSP equals sp.MaSP
                               select new Models.ImportProduct
                               {
                                   MaNhap = ip.MaNhap,
                                   TenSP = sp.TenSP,
                                   SoLuong = ip.SoLuong,
                                   DonGia = ip.DonGia,
                                   NgayNhap = ip.NgayNhap,
                                   TongTien = ip.TongTien,
                                   GhiChu = ip.GhiChu
                               };

                customer = L2EQuery.ToList();

            }
            return customer;
        }
        public ImportProduct GetImportProductByID(int id)
        {
            Models.ImportProduct importproduct;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from ip in context.NhapSanPhams
                               join sp in context.SanPhams on ip.MaSP equals sp.MaSP
                               where ip.MaNhap == id
                               select new Models.ImportProduct
                               {
                                   MaNhap = ip.MaNhap,
                                   TenSP = sp.TenSP,
                                   SoLuong = ip.SoLuong,
                                   DonGia = ip.DonGia,
                                   NgayNhap = ip.NgayNhap,
                                   TongTien = ip.TongTien,
                                   GhiChu = ip.GhiChu
                               };

                importproduct = L2EQuery.SingleOrDefault();

            }
            return importproduct;
        }
    }
}