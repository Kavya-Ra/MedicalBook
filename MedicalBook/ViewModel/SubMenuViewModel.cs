using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalBook.ViewModel
{
    public class SubMenuViewModel
    {
        public int sm1_id { get; set; }
        public int sm1_menuid { get; set; }
        public string sm1_name { get; set; }
        public string sm1_desc { get; set; }
        public string sm1_url { get; set; }
        public int sm1_level { get; set; }

        public List<SubMenu2ViewModel> GetSubMenu_2s { get; set; }
    }
}