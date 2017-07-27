using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class Feedback
    {
        public int MaPH { get; set; }
        public string TieuDe { get; set; }
        public string TenNguoiGui { get; set; }
        public string Email { get; set; }
        public string NoiDung { get; set; }
        public List<Feedback> GetFeedbackList()
        {
            List<Models.Feedback> a;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from ph in context.PhanHois
                               select new Models.Feedback
                               {
                                   MaPH = ph.MaPH,
                                   TieuDe = ph.TieuDe,
                                   TenNguoiGui = ph.TenNguoiGui,
                                   Email = ph.Email,
                                   NoiDung = ph.NoiDung
                               };

                a = L2EQuery.ToList();

            }
            return a;
        }
    }
}