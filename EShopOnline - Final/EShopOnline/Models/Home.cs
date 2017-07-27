using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopOnline.Models
{
    public class Home
    {
       public List<Product> FeaturePhone { get; set; }
       public List<BrandHome> brand { get; set; }
       public List<Product> Phone { get; set; } 

    }
    public class BrandHome
    {
        public int MaNSX { get; set; }
        public string TenNSX { get; set; }
        public int SoLuong { get; set; }
    }
}