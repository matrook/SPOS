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
            this.PT_SubCategory = new List<SelectListItem>();
            this.PT_Category = new List<SelectListItem>();
            //this.Cities = new List<SelectListItem>();
        }

        public List<SelectListItem> PT_SubCategory { get; set; }
        public List<SelectListItem> PT_Category { get; set; }
        //public List<SelectListItem> Cities { get; set; }

        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        //public int CityId { get; set; }

        public T_SubCategory SubCategories { get; set; }
        public T_Category Categories { get; set; }
        public T_PROD Products { get; set; }
    }
}