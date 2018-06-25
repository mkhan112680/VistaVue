using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class User
    {

        public User()
        {

        }

        //user
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool LoginFlag { get; set; }
        public bool IsActive { get; set; }
        //user registration
        public int UserRegistrationID { get; set; }
        public bool? MOU { get; set; }
        public DateTime? MOUDate { get; set; }
        public bool? AssesmentSurvey { get; set; }
        public bool? PayeeInformation { get; set; }
        public DateTime? PayeeInformationDate { get; set; }
        public DateTime? AssesmentSurveyDate { get; set; }

        private List<string> roles = new List<string>();

        public List<string> Roles
        {

            get
            {
                //if (roles == null)
                //    roles = new List<string>();

                return roles;
            }
            set
            {
                roles = value;
            }

        }


        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
