using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class InviteeModelWaitlist 
    {
        public InviteeModelWaitlist()
        {
            ID = -1;

            Province = new ProvinceModel() { ID = 0 };
            
        }

        
        public int ID { get; set; }

        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }
 
        [Required(ErrorMessage = "*")]
        public string City { get; set; }

        public ProvinceModel Province { get; set; }

        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        public string RegCode { get; set; }

    }
}