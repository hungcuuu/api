using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Table
    {
        public Table()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }
        public int? Status { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsCircle { get; set; }
        public int TableRow { get; set; }
        public int TableColumn { get; set; }
        public int SpanTableRow { get; set; }
        public int SpanTableColumn { get; set; }
        public int Floor { get; set; }
        public int? CurrentOrderId { get; set; }
        public DateTime? CurrentOrderDate { get; set; }
        public int? ForOrderType { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
