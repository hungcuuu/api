using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class OrdersController : BaseController
    {
        public OrdersController(IGuestLogic guestLogic) : base(guestLogic)
        {
        }


    }
}