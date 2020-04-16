using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public partial class Category
    {
        //public Category()
        //{
        //    Product = new HashSet<Product>();
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsUsed { get; set; }
        public int? IsExtra { get; set; }
        public string AdjustmentNote { get; set; }
        public string ImageFontAwsomeCss { get; set; }
        public int? ParentCateId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Product { get; set; }
    }
}
