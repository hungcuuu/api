using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Fcamount { get; set; }
        public string Notes { get; set; }
        public DateTime PayTime { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public string CardCode { get; set; }
        public bool? Active { get; set; }
        public string Code { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}
