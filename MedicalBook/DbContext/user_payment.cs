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
    
    public partial class user_payment
    {
        public int up_id { get; set; }
        public int up_userid { get; set; }
        public string up_paymenttype { get; set; }
        public string up_provider { get; set; }
        public int up_accountno { get; set; }
        public System.DateTime up_expiry { get; set; }
        public int up_createdby { get; set; }
        public System.DateTime up_createddate { get; set; }
        public int up_modifiedby { get; set; }
        public System.DateTime up_modifieddate { get; set; }
        public int up_deletedby { get; set; }
        public System.DateTime up_deleteddate { get; set; }
        public int up_isdeleted { get; set; }
    
        public virtual user user { get; set; }
    }
}
