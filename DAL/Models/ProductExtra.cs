using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductExtra
    {
        public int ProductExtraId { get; set; }
        public string PrimaryProductCode { get; set; }
        public string ExtraProductCode { get; set; }
        public bool IsEnable { get; set; }
        public bool? IsDisplayed { get; set; }
        public int? MaxItem { get; set; }
        public double? Price { get; set; }
        public decimal? TimeStamp { get; set; }
        public bool IsUsed { get; set; }
    }
}
