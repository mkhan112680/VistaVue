using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VistaDM.Web.Models
{
    public class InviteeModel
    {
        public InviteeModel()
        {
            ID = -1;
        }

        public SelectList Provinces { get; set; }

        public int ID { get; set; }
        
        [Required(ErrorMessage="*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        public string ClinicName { get; set; }

        [Required(ErrorMessage = "*")]
        public string Address { get; set; }

        [Required(ErrorMessage = "*")]
        public string City { get; set; }

        [Required(ErrorMessage = "*")]
        public ProvinceModel Province { get; set; }

        [Required(ErrorMessage = "*")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public string FaxNumber { get; set; }

        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        public string ConfirmPassword { get; set; }

        public string RegCode { get; set; }
    
    }
}