using DAL.Models;
using System;
using System.Collections.Generic;

namespace BLL.RequestModels
{
    public class RequestOrderDetail
    {
        public int customerQuantity { get; set; }
        public List<ProductOrder> list { get; set; }
    }

    
}
