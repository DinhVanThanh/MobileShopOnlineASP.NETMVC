using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class Cart
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string Hinh { get; set; }
        public long? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public long? TongTien { get { return DonGia * SoLuong; } set { value = DonGia * SoLuong; } }
    }
}