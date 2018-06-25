﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class ProvinceModel
    {
        [Required( ErrorMessage="*")]
        public int? ID { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }
}