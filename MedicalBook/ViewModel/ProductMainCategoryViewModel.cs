using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalBook.ViewModel
{
    public class ProductMainCategoryViewModel
    {
        public int mpc_id { get; set; }
        public string mpc_name { get; set; }
        public string mpc_desc { get; set; }
        public int mpc_createdby { get; set; }
        public System.DateTime mpc_createddate { get; set; }
        public int mpc_modifiedby { get; set; }
        public System.DateTime mpc_modifieddate { get; set; }
        public int mpc_deletedby { get; set; }
        public System.DateTime mpc_deleteddate { get; set; }
        public int mpc_isdeleted { get; set; }

        public List<ProductCategoryViewModel> productCategoryViews { get; set; }
    }
}