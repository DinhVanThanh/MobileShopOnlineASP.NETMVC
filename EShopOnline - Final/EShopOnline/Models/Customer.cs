using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class Customer 
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public List<Customer> GetCustomer()
        {
            List<Models.Customer> customer;
            using (var context = new BanDoDienTuEntities())
            {
                var L2EQuery = from kh in context.KhachHangs
                               select new Models.Customer
                               {
                                   MaKH = kh.MaKH,
                                   TenKH = kh.TenKH,
                                   SDT = kh.SDT,
                                   DiaChi = kh.DiaChi,
                                   Email = kh.Email
                               };

                customer = L2EQuery.ToList();

            }
            return customer;
        }
       
    }
}