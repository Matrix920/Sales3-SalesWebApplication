//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_salesperson.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CommissionT
    {
        public int CommID { get; set; }
        public int SalesPersonID { get; set; }
        public int CommMonth { get; set; }
        public int CommYear { get; set; }
        public decimal CommSouthern { get; set; }
        public decimal CommCoastal { get; set; }
        public decimal CommNorthern { get; set; }
        public decimal CommEastern { get; set; }
        public decimal CommLebanon { get; set; }
        public decimal CommTotal { get; set; }
    
        public virtual SalesPersonT SalesPersonT { get; set; }
    }
}
