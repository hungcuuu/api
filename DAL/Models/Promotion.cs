using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Promotion
    {
        public int PromotionId { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionName { get; set; }
        public string PromotionClassName { get; set; }
        public string Description { get; set; }
        public string ImageCss { get; set; }
        public int ApplyLevel { get; set; }
        public int GiftType { get; set; }
        public bool IsForMember { get; set; }
        public bool IsActive { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? ApplyFromTime { get; set; }
        public int? ApplyToTime { get; set; }
        public int? PromotionType { get; set; }
        public bool? IsVoucher { get; set; }
        public bool? IsApplyOnce { get; set; }
        public bool? Active { get; set; }
    }
}
