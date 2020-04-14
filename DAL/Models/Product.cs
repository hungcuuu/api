using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ShortName { get; set; }
        public double Price { get; set; }
        public string PicUrl { get; set; }
        public int CatId { get; set; }
        public bool? IsAvailable { get; set; }
        public double DiscountPercent { get; set; }
        public double DiscountPrice { get; set; }
        public int ProductType { get; set; }
        public int DisplayOrder { get; set; }
        public bool? HasExtra { get; set; }
        public bool IsFixedPrice { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int? ColorGroup { get; set; }
        public int Group { get; set; }
        public bool? IsMenuDisplay { get; set; }
        public int? GeneralProductId { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public int? MaxExtra { get; set; }
        public bool? IsMostOrder { get; set; }
        public bool IsUsed { get; set; }
        public int? ProductParentId { get; set; }
        public int PrintGroup { get; set; }
        public bool IsDefaultChildProduct { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
