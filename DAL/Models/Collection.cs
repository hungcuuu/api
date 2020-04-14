using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Collection
    {
        public int Id { get; set; }
        public int? Code { get; set; }
        public int? Active { get; set; }
    }
}
