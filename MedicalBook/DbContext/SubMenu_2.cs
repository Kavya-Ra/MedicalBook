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
    
    public partial class SubMenu_2
    {
        public int sm2_id { get; set; }
        public int sm2_menuid { get; set; }
        public string sm2_name { get; set; }
        public string sm2_desc { get; set; }
        public string sm2_url { get; set; }
        public int sm2_level { get; set; }
    
        public virtual SubMenu_1 SubMenu_1 { get; set; }
    }
}
