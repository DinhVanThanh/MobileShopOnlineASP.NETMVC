using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopOnline.Models
{
    public class USER
    {
        public int MaTK { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ChucNang { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public int? MaPQ { get; set; }
        public Models.USER GetUser(string username, string password)
        {
            Models.USER a;
            using (var context = new BanDoDienTuEntities())
            {
                var user = from u in context.Users
                           join pq in context.Roles on u.MaPQ equals pq.MaPQ
                           join kh in context.KhachHangs on u.MaTK equals kh.MaTK
                           where u.Username == username && u.Password == password
                           select new Models.USER { MaPQ = u.MaPQ, MaKH = kh.MaKH, ChucNang = pq.ChucNang,
                               TenKH = kh.TenKH };

                a = user.SingleOrDefault();
            }
                
            return a;
        }
       
    }
}