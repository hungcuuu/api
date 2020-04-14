﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public partial class OrderPromotionMapping
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionDetailCode { get; set; }
        public int MappingIndex { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? DiscountRate { get; set; }
        public int? TmpMappingId { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}
