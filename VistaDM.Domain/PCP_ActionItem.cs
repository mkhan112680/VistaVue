using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class PCP_ActionItem
    {
        [CsvColumnName(Name = "FirstName", Order = 1)]
        public string FirstName {get;set;}
		
        [CsvColumnName(Name = "LastName", Order = 1)]
        public string LastName {get;set;}
		
        [CsvColumnName(Name = "WorkPlace", Order = 1)]
        public string WorkPlace {get;set;} 
		
        [CsvColumnName(Name = "Address", Order = 1)]
        public string Address {get;set;} 
	   
        [CsvColumnName(Name = "City", Order = 1)]	
        public string City {get;set;}
	    
        [CsvColumnName(Name = "Province", Order = 1)]	
        public string Province {get;set;} 
	   
        [CsvColumnName(Name = "PostalCode", Order = 1)]	
        public string PostalCode {get;set;}
	   
        [CsvColumnName(Name = "Phone", Order = 1)]	
        public string Phone {get;set;}
	   
        [CsvColumnName(Name = "Fax", Order = 1)]	
        public string Fax {get;set;}
	   
        [CsvColumnName(Name = "UserName", Order = 1)]	
        public string UserName {get;set;}
	   
        [CsvColumnName(Name = "MOU", Order = 1)]	
        public string MOU  {get;set;}
	   
        [CsvColumnName(Name = "Payee", Order = 1)]	
        public string Payee {get;set;}
	   
        [CsvColumnName(Name = "NeedsAsssesment", Order = 1)]	
        public string NeedsAsssesment  {get;set;}
	   
        [CsvColumnName(Name = "ePAF1", Order = 1)]	
        public int ePAF1 {get;set;}
	   
        [CsvColumnName(Name = "eMAf1", Order = 1)]	
        public int eMAf1 {get;set;}
    }
}
