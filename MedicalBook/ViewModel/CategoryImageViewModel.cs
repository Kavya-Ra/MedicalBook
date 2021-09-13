using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicalBook.ViewModel
{
    public class CategoryImageViewModel
    {

        public int pcimg_id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int maincategory_id { get; set; }
      
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }
    }
}