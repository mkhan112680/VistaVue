using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaVue.Models
{
    public class Payee
    {

        public enum PayeeType
        {
            NONE = 0,
            Company = 1,
            Personal = 2
        }
        public Payee()
        {
             
        }

        public int ID { get; set; }
        public int UserID { get; set; }

//        public ProvinceModel Province { get; set; }

        public string CheckPayableTo { get; set; }

        public string InternalRefNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string AttentionTo { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string TaxNumber { get; set; }

        public string Instructions { get; set; }

        public DateTime? DateEntered { get; set; }

        public PayeeType Payee_Type { get; set; }
    }
}