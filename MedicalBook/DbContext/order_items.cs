//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalBook.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class order_items
    {
        public int oi_id { get; set; }
        public int oi_orderid { get; set; }
        public int oi_productid { get; set; }
        public int oi_quantity { get; set; }
        public int oi_createdby { get; set; }
        public System.DateTime oi_createddate { get; set; }
        public int oi_modifiedby { get; set; }
        public System.DateTime oi_modifieddate { get; set; }
        public int oi_deletedby { get; set; }
        public System.DateTime oi_deleteddate { get; set; }
        public int oi_isdeleted { get; set; }
    
        public virtual order_details order_details { get; set; }
        public virtual product product { get; set; }
    }
}
