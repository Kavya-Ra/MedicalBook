using MedicalBook.DbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicalBook.ViewModel
{
    public class ProductViewModel
    {
        public int p_id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string p_name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string p_desc { get; set; }
        [Required]
        [Display(Name = "Year")]
        public int p_year { get; set; }
        [Required]
        [Display(Name = "Edition")]
        public string p_edition { get; set; }
        [Required]
        [Display(Name = "ISBN")]
        public string p_isbn { get; set; }
        [Required]
        [Display(Name = "Author")]
        public int author_id { get; set; }
        [Required]
        [Display(Name = "Publisher")]
        public int publisher_id { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal p_price { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int category_id { get; set; }
        [Required]
        [Display(Name = "Inventory")]
        public int inventory_id { get; set; }
        [Required]
        [Display(Name = "Discount")]
        public int discount_id { get; set; }
     
        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }

        public List<product_image> Product_Images_list { get; set; }

        public product_image product_Image { get; set; }


    }
}