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
    using System.ComponentModel.DataAnnotations;

    public partial class GetProductByCategoryId_Result
    {
        [Key]
        public int p_id { get; set; }
        public string p_name { get; set; }
        public string p_desc { get; set; }
        public decimal p_price { get; set; }
        public int p_year { get; set; }
        public string p_edition { get; set; }
        public string p_isbn { get; set; }
        public int category_id { get; set; }
        public int inventory_id { get; set; }
        public int discount_id { get; set; }
        public int author_id { get; set; }
        public int publisher_id { get; set; }
        public int p_createdby { get; set; }
        public System.DateTime p_createddate { get; set; }
        public int p_modifiedby { get; set; }
        public System.DateTime p_modifieddate { get; set; }
        public int p_deletedby { get; set; }
        public System.DateTime p_deleteddate { get; set; }
        public int p_isdeleted { get; set; }
        public int pim_id { get; set; }
        public string p_image { get; set; }
        public int product_id { get; set; }
    }
}
