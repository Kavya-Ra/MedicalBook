using MedicalBook.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalBook.ViewModel
{
    public class HomeViewModel
    {
      public List<GetCategoryWiseImage_Result> getCategoryWiseImage_Results { get; set; }
      
        public List<product_maincategory> GetProduct_Maincategories { get; set; }

        public List<product_category> product_Categories { get; set; }

        public List<GetProductWithImageList_Result> getProductWithImages { get; set; }

        public List<ProductMainCategoryViewModel> productMainCategoryViewModels { get; set; }


    }
}