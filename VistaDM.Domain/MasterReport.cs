using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class MasterReport
    {
        [CsvColumnName(Name = "RegCode", Order = 1)]
        public string RegCode { get; set; }

        [CsvColumnName(Name = "FirstName", Order = 2)]
        public string FirstName { get; set; }

        [CsvColumnName(Name = "LastName", Order = 3)]
        public string LastName { get; set; }

        [CsvColumnName(Name = "FSA", Order = 4)]
        public string FSA { get; set; }

        [CsvColumnName(Name = "PostalCode", Order = 5)]
        public string PostalCode { get; set; }

        [CsvColumnName(Name = "Status", Order = 6)]
        public string Status { get; set; }

        [CsvColumnName(Name = "Clinic", Order = 7)]
        public string Clinic { get; set; }

        [CsvColumnName(Name = "Address", Order = 8)]
        public string Address { get; set; }

        [CsvColumnName(Name = "City", Order = 9)]
        public string City { get; set; }

        [CsvColumnName(Name = "Province", Order = 10)]
        public string Province { get; set; }

        [CsvColumnName(Name = "Phone", Order = 11)]
        public string Phone { get; set; }

        [CsvColumnName(Name = "Fax", Order = 12)]
        public string Fax { get; set; }

        [CsvColumnName(Name = "DocType", Order = 13)]
        public string DocType { get; set; }

        [CsvColumnName(Name = "BITerritoryID", Order = 14)]
        public int? BITerritoryID { get; set; }

        [CsvColumnName(Name = "LillyID", Order = 15)]
        public string LillyID { get; set; }

        //[CsvColumnName(Name = "LillyTerritoryID", Order = 14)]
        //public string LillyTerritoryID { get; set; }
    }
}
