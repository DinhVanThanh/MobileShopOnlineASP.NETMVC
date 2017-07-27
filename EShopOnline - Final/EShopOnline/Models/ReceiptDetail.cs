using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class ReceiptDetail
    {
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int? SoLuong { get; set; }
        public long? TongTien { get; set; }
        public ReceiptDetail GetReceiptDetailByMaSP(int id)
        {
            ReceiptDetail a;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from cthd in context.ChiTietHoaDons
                               join sp in context.SanPhams on cthd.MaSP equals sp.MaSP
                               where cthd.MaSP == id
                               select new Models.ReceiptDetail
                               {
                                   MaSP = cthd.MaSP,
                                   MaHD = cthd.MaHD,
                                   TenSP = sp.TenSP,
                                   SoLuong = cthd.SoLuong,
                                   TongTien = cthd.TongTien
                               };

                a = L2EQuery.SingleOrDefault();

            }
            return a;
        }
        public List<ReceiptDetail> GetReceiptDetailByMaHD(int id)
        {
            List<ReceiptDetail> a;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from cthd in context.ChiTietHoaDons
                               join sp in context.SanPhams on cthd.MaSP equals sp.MaSP
                               where cthd.MaHD == id
                               select new Models.ReceiptDetail
                               {
                                   MaSP = cthd.MaSP,
                                   MaHD = cthd.MaHD,
                                   TenSP = sp.TenSP,
                                   SoLuong = cthd.SoLuong,
                                   TongTien = cthd.TongTien
                               };

                a = L2EQuery.ToList();

            }
            return a;
        }
    }
}