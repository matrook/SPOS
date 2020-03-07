using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPOS.Models
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.T_SubCategory = new List<SelectListItem>();
            this.T_Category = new List<SelectListItem>();
            //this.Cities = new List<SelectListItem>();
        }

        public List<SelectListItem> T_SubCategory { get; set; }
        public List<SelectListItem> T_Category { get; set; }
        //public List<SelectListItem> Cities { get; set; }

        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        //public int CityId { get; set; }

        public T_SubCategory subCategories { get; set; }
        public T_Category categories { get; set; }
        public T_PROD products { get; set; }
    }
}