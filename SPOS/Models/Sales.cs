using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SPOS.Models
{
    public class Sales
    {

        public Sales()
        {
            this.T_SALES_DTL = new List<SelectListItem>();
            this.T_SALES_MST = new List<SelectListItem>();
            //this.Cities = new List<SelectListItem>();
        }

        public List<SelectListItem> T_SALES_DTL { get; set; }
        public List<SelectListItem> T_SALES_MST { get; set; }
        //public List<SelectListItem> Cities { get; set; }

        public int ReceiveIdDTL { get; set; }
        public int ReceiveDetailId { get; set; }
        //public int CityId { get; set; }

        public T_SALES_DTL receiveIdDTL { get; set; }
        public T_SALES_MST ReceiveDetailIdMST { get; set; }




    }
}