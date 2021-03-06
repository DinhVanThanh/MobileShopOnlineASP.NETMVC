//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShopOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            this.NhapSanPhams = new HashSet<NhapSanPham>();
        }
    
        public int MaSP { get; set; }
        public int MaCTSP { get; set; }
        public string TenSP { get; set; }
        public Nullable<int> MaLoai { get; set; }
        public Nullable<int> SoLuongTrongKho { get; set; }
        public Nullable<int> MaNSX { get; set; }
        public string TinhTrang { get; set; }
        public string NoiDung { get; set; }
        public string Hinh { get; set; }
        public Nullable<long> GiaBan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhapSanPham> NhapSanPhams { get; set; }
        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
