using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class RoleName
    {
        //public RoleName()
        //{
        //    Account = new HashSet<Account>();
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Account { get; set; }
    }
}
