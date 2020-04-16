using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public partial class Account
    {
        //public Account()
        //{
        //      DateReport = new HashSet<DateReport>();
        //}

        public string AccountId { get; set; }
        public string AccountPassword { get; set; }
        public string StaffName { get; set; }
        public int Role { get; set; }
        public bool IsUsed { get; set; }
        [JsonIgnore]
        public virtual RoleName RoleNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<DateReport> DateReport { get; set; }
    }
}
