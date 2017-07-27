using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class ProductDetail
    {

        public int MaCTSP { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public long? GiaBan { get; set; }
        public string Hinh { get; set; }
        public string ManHinh { get; set; }
        public string HDH { get; set; }
        public string Camera { get; set; }
        public string RAM { get; set; }
        public string BoNhoTrong { get; set; }
        public string DungLuongPin { get; set; }
        public Models.ProductDetail GetProductDetailByid(int id)
        {
            Models.ProductDetail prode = new ProductDetail();
            using (var context = new BanDoDienTuEntities() )
            {
                var a = from sp in context.SanPhams
                        join ct in context.ChiTietSanPhams on sp.MaCTSP equals ct.MaCTSP
                        where sp.MaSP == id
                        select new Models.ProductDetail { MaCTSP = sp.MaCTSP, ManHinh = ct.ManHinh, HDH = ct.HDH,
                        Camera = ct.Camera, RAM = ct.RAM, BoNhoTrong = ct.BoNhoTrong, Hinh = sp.Hinh,
                        DungLuongPin = ct.DungLuongPin, TenSP = sp.TenSP, GiaBan = sp.GiaBan, MaSP = sp.MaSP};
                prode = a.SingleOrDefault();
            }
            return prode;
        }
    }
}