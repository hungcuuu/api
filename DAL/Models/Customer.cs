﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? Nationality { get; set; }
        public string Notes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Order { get; set; }
    }
}
