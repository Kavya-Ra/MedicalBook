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
    
    public partial class user_address
    {
        public int ua_id { get; set; }
        public int ua_userid { get; set; }
        public string address_line1 { get; set; }
        public string address_line2 { get; set; }
        public string city { get; set; }
        public int pincode { get; set; }
        public string country { get; set; }
        public int telephone { get; set; }
        public int mobile { get; set; }
        public int ua_createdby { get; set; }
        public System.DateTime ua_createddate { get; set; }
        public int ua_modifiedby { get; set; }
        public System.DateTime ua_modifieddate { get; set; }
        public int ua_deletedby { get; set; }
        public System.DateTime ua_deleteddate { get; set; }
        public int ua_isdeleted { get; set; }
    
        public virtual user user { get; set; }
    }
}
