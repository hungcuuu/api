using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class CategoryExtra
    {
        public int CategoryExtraId { get; set; }
        public int PrimaryCategoryCode { get; set; }
        public int ExtraCategoryCode { get; set; }
        public bool IsEnable { get; set; }
    }
}
