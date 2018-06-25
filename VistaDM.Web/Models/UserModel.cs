using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public enum PhysicanType
    {
       	PCP = 1 ,
        CS = 2
    }
    
    public class UserModel
    {

        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsTest { get; set; }

        public bool? MOU { get; set; }
        public DateTime? MOUDate { get; set; }
        public bool? AssesmentSurvey { get; set; }
        public DateTime? AssesmentSurveyDate { get; set; }

        public bool PAF1_Complete { get; set; }

        public PayeeModel Payee { get; set; }
        
        public PhysicanType PhysicanType { get; set; }

        public bool IsPCP
        {
            get {
                return PhysicanType == PhysicanType.PCP;
            }

        }
    }
}