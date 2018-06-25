using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class GlanceReport
    {
        [CsvColumnName(Name = "Province", Order = 1)]
        public string Province { get; set; }

        [CsvColumnName(Name = "Invited", Order = 2)]
        public int Invited { get; set; }

        [CsvColumnName(Name = "Registered", Order = 3)]
        public int Registered { get; set; }

        [CsvColumnName(Name = "MOU", Order = 4)]
        public int MOU { get; set; }

        [CsvColumnName(Name = "Payee", Order = 5)]
        public int Payee { get; set; }

        [CsvColumnName(Name = "NA", Order = 6)]
        public int NA { get; set; }

        [CsvColumnName(Name = "ePAF", Order = 7)]
        public int ePAF { get; set; }

        [CsvColumnName(Name = "eMAF", Order = 8)]
        public int eMAF { get; set; }

      
    }
}
