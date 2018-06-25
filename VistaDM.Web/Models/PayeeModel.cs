using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VistaDM.Web.Controllers;
 
 

namespace VistaDM.Web.Models
{

    public enum PayeeType
    {
        NONE     = 0,
        Company  = 1,
        Personal = 2
    }
    
    
    public class PayeeModel
    {
        
        public PayeeModel()
        {

            Provinces = new SelectList((new ProvinceController()).GetList(), "ID", "FullName");
        }
        
        
        public SelectList Provinces
        {
            get;
            set;
        }

        public int ID { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "*")]
        public ProvinceModel Province  { get; set; }

        [Required(ErrorMessage = "*")]
        public string CheckPayableTo { get; set; }
        
        public string InternalRefNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public string Address1 { get; set; }
        
        public string Address2 { get; set; }
        
        public string AttentionTo { get; set; }

        [Required(ErrorMessage = "*")]
        public string City { get; set; }

        [Required(ErrorMessage = "*")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "*")]
        public string TaxNumber { get; set; }
        
        public string Instructions { get; set; }

        public DateTime? DateEntered { get; set; }

        public PayeeType PayeeType { get; set; }

    }
}