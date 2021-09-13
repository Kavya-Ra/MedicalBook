using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalBook.ViewModel
{
    public class ProductCategoryViewModel
    {
        public int pc_id { get; set; }
        public int pc_mcid { get; set; }
        public string pc_name { get; set; }
        public string pc_desc { get; set; }
        public int pc_createdby { get; set; }
        public System.DateTime pc_createddate { get; set; }
        public int pc_modifiedby { get; set; }
        public System.DateTime pc_modifieddate { get; set; }
        public int pc_deletedby { get; set; }
        public System.DateTime pc_deleteddate { get; set; }
        public int pc_isdeleted { get; set; }
    }
}