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
    
    public partial class discount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public discount()
        {
            this.products = new HashSet<product>();
        }
    
        public int dis_id { get; set; }
        public string dis_name { get; set; }
        public string dis_desc { get; set; }
        public int dis_percentage { get; set; }
        public int dis_active { get; set; }
        public int dis_createdby { get; set; }
        public System.DateTime dis_createddate { get; set; }
        public int dis_modifiedby { get; set; }
        public System.DateTime dis_modifieddate { get; set; }
        public int dis_deletedby { get; set; }
        public System.DateTime dis_deleteddate { get; set; }
        public int dis_isdeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}
