using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
            OrderPromotionMapping = new HashSet<OrderPromotionMapping>();
            Payment = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        public double? TotalAmount { get; set; }
        public double? Discount { get; set; }
        public double? DiscountOrderDetail { get; set; }
        public double? FinalAmount { get; set; }
        public int? OrderStatus { get; set; }
        public int? OrderType { get; set; }
        public string Notes { get; set; }
        public string FeeDescription { get; set; }
        public string CheckInPerson { get; set; }
        public string CheckOutPerson { get; set; }
        public string ApprovePerson { get; set; }
        public int? CustomerId { get; set; }
        public int? SourceId { get; set; }
        public int? TableId { get; set; }
        public bool IsFixedPrice { get; set; }
        public DateTime? LastRecordDate { get; set; }
        public string ServedPerson { get; set; }
        public string DeliveryAddress { get; set; }
        public int? DeliveryStatus { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryCustomer { get; set; }
        public int? TotalInvoicePrint { get; set; }
        public double? Vat { get; set; }
        public double? Vatamount { get; set; }
        public int? NumberOfGuest { get; set; }
        public int? GroupPaymentStatus { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public string Att4 { get; set; }
        public string Att5 { get; set; }
        public string PromotionCode { get; set; }
        public string PasswordWifi { get; set; }
        public int? CustomerType { get; set; }
        public DateTime? LastModifiedPayment { get; set; }
        public DateTime? LastModifiedOrderDetail { get; set; }
        public int? PersonCount { get; set; }
        public string PaymentCode { get; set; }
        public bool? Active { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Source Source { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<OrderPromotionMapping> OrderPromotionMapping { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
