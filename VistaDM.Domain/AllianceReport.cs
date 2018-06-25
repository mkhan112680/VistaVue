using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class AllianceReport
    {
        [CsvColumnName(Name = "FirstName", Order = 1)]
        public string FirstName { get; set; }

        [CsvColumnName(Name = "LastName", Order = 1)]
        public string LastName { get; set; }

        [CsvColumnName(Name = "CompanyName", Order = 1)]
        public string CompanyName { get; set; }

        [CsvColumnName(Name = "Role", Order = 1)]
        public string Role { get; set; }

        [CsvColumnName(Name = "All", Order = 1)]
        public string All { get; set; }

        [CsvColumnName(Name = "BC", Order = 1)]
        public string BC { get; set; }

        [CsvColumnName(Name = "AB", Order = 1)]
        public string AB { get; set; }

        [CsvColumnName(Name = "SK", Order = 1)]
        public string SK { get; set; }

        [CsvColumnName(Name = "MB", Order = 1)]
        public string MB { get; set; }

        [CsvColumnName(Name = "ON", Order = 1)]
        public string ON { get; set; }

        [CsvColumnName(Name = "QC", Order = 1)]
        public string QC { get; set; }

        [CsvColumnName(Name = "NS", Order = 1)]
        public string NS { get; set; }

        [CsvColumnName(Name = "NB", Order = 1)]
        public string NB { get; set; }

        [CsvColumnName(Name = "NL", Order = 1)]
        public string NL { get; set; }

        [CsvColumnName(Name = "PEI", Order = 1)]
        public string PEI { get; set; }
    }
}
