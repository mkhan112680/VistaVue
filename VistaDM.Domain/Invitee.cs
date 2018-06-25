using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public enum PhysicanType
    {
        PCP = 1,
        CS = 2
    }
    
    
    public class Invitee 
    {

        
        public int PhysicianID { get; set; }

        public int? UserID { get; set; }

        public string UserName { get; set; }

        public string Speciality { get; set; }
        
        public string OneKeyID { get; set; }

        public string RegistrationCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PrimaryWorkplace { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ProvinceName { get; set; }

        public int ProvinceID { get; set; }

        public Province Province { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string OptInEmail { get; set; }

        public VistaDM.Domain.Enums.PhysicianType PhysicianType { get; set; }
        
        //public string RegistrationStatus { get; set; }

        public Nullable<int> RegistrationStatus { get; set; }

        public RegistrationStatus ReStatus { get; set; }

        public Nullable<int> Status { get; set; }

        public DateTime? InvitationSentDate { get; set; }

        public DateTime? InvitationSentDateFrench { get; set; }

        public bool Invited
        {
            get;
            set;
        }

        public string CellPhone { get; set; }
        
        public string Comments { get; set; }

        public String FSA { get; set; }

        public bool IsAdminApproved { get; set; }

        public string YourFirstName  { get; set; }
        
        public string YourLastName   { get; set; }
        
        public string YourEmail { get; set; }

        public int? BITerritoryID { get; set; }

        public string LillyID { get; set; }  
 
    }
}
