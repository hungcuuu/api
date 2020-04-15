using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.RequestModels
{
    public class RequestOrderDetail
    {
        public int customerQuantity;
        public List<ProductOrder> list;
    }

    public class ProductOrder
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}
