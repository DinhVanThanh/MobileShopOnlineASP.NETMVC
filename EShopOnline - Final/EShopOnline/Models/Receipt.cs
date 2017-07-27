using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class Receipt
    {
        public int MaHD { get; set; }
        public DateTime? NgayLap { get; set; }
        public long? TongTien { get; set; }
        public string TinhTrangDonHang { get; set; }
        public string TenKH { get; set; }

        public List<Models.Receipt> GetReceipt()
        {
            List<Models.Receipt> a;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from hd in context.HoaDons
                               join kh in context.KhachHangs on hd.MaKH equals kh.MaKH
                               select new Models.Receipt
                               {
                                   MaHD = hd.MaHD,
                                   NgayLap = hd.NgayLap,
                                   TongTien = hd.TongTien,
                                   TinhTrangDonHang = hd.TinhTrangDonHang,
                                   TenKH = kh.TenKH
                               };

                a = L2EQuery.ToList();

            }
            return a;
        }
        public Receipt GetReceiptByID(int id)
        {
            Receipt a;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from hd in context.HoaDons
                               join kh in context.KhachHangs on hd.MaKH equals kh.MaKH
                               where hd.MaHD == id
                               select new Models.Receipt
                               {
                                   MaHD = hd.MaHD,
                                   NgayLap = hd.NgayLap,
                                   TongTien = hd.TongTien,
                                   TinhTrangDonHang = hd.TinhTrangDonHang,
                                   TenKH = kh.TenKH
                               };

                a = L2EQuery.SingleOrDefault();

            }
            return a;
        }
    }
}