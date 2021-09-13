using MedicalBook.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalBook.ViewModel
{
    public class MenuViewModel
    {
        public int m_id { get; set; }
        public string m_name { get; set; }
        public string m_desc { get; set; }
        public string m_url { get; set; }
        public int m_level { get; set; }
        public List<SubMenuViewModel> subMenuViewModels { get; set; }

    }
}