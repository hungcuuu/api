using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Source
    {
        public Source()
        {
            Order = new HashSet<Order>();
        }

        public int SourceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
