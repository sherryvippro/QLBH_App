//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBH_App.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHDB
    {
        public string MaHDB { get; set; }
        public string MaSP { get; set; }
        public Nullable<int> SLBan { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
    
        public virtual HDBan HDBan { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}