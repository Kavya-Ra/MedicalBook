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
    
    public partial class product_inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product_inventory()
        {
            this.products = new HashSet<product>();
        }
    
        public int pi_id { get; set; }
        public int pi_quantity { get; set; }
        public int pi_createdby { get; set; }
        public System.DateTime pi_createddate { get; set; }
        public int pi_modifiedby { get; set; }
        public System.DateTime pi_modifieddate { get; set; }
        public int pi_deletedby { get; set; }
        public System.DateTime pi_deleteddate { get; set; }
        public int pi_isdeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}