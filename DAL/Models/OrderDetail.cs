
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double? Discount { get; set; }
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? Status { get; set; }
        public string Notes { get; set; }
        public double? TaxValue { get; set; }
        public int? ProductType { get; set; }
        public int? ParentId { get; set; }
        public int? ProductOrderType { get; set; }
        public int? ItemQuantity { get; set; }
        public int? TmpDetailId { get; set; }
        public string PromotionCode { get; set; }
        public int? OrderPromotionMappingId { get; set; }
        public int? OrderDetailPromotionMappingId { get; set; }
        public bool? Active { get; set; }
        public string Code { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
