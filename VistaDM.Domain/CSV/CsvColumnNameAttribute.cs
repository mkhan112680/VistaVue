using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class CsvColumnNameAttribute : Attribute
    {

        public bool Export { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }

        public CsvColumnNameAttribute()
        {
            Export = true;
            Order = int.MaxValue; // so unordered columns are at the end
        }

    }
}
