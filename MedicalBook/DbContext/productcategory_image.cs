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
    
    public partial class productcategory_image
    {
        public int pcimg_id { get; set; }
        public string pcimg_image { get; set; }
        public int maincategory_id { get; set; }
        public System.DateTime pcimg_date { get; set; }
    
        public virtual product_maincategory product_maincategory { get; set; }
    }
}
