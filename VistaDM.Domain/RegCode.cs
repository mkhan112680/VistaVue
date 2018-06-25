using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VistaDM.Domain
{
    public class RegCode
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public bool? Used { get; set; }
    }
}
