using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.RequestModels;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class OrdersController : BaseController
    {
        public OrdersController(IGuestLogic guestLogic) : base(guestLogic)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetOrdersList()
        {
            try
            {
                var orders = _logic.GetOrdersList();
                if (orders.Count == 0)
                    return NotFound("There are no orders");

                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.Message + e.ToString());
            }
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetOrderDetail(int id)
        {
            try
            {
                var product = _logic.GetOrderDetailsByOrderId(id);
                if (product == null)
                    return NotFound("There are no Products");
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString() + e.Message);
            }
        }


        //[AllowAnonymous]
        //[HttpPost]
        //#region RepCode 200 400 401 404 500
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //#endregion
        //public IActionResult GetPayment(MoMoRequest moMoRequest)
        //{
        //    try
        //    {
        //        PointOfSaleDBPassioContext db = new PointOfSaleDBPassioContext();
        //        if (moMoRequest.status == 0)
        //        {
        //            var customer = new Customer { Email = "ahjhj" };
        //            db.Customer.Add(customer);
        //            db.SaveChanges();
        //            return Ok();
        //        }

        //        return BadRequest();

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest("System Error:\n " + e.Message + e.ToString());
        //    }
        //}

        [AllowAnonymous]
        [HttpPost]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult InsertOrder([FromBody] RequestOrderDetail requestOrderDetail)
        {
            try
            {
                var sum = _logic.GetOrders().Count() + 1;
                var orderCode = "B" + sum.ToString().PadLeft(8, '0');

                if (_logic.InsertOrder(orderCode, requestOrderDetail.customerQuantity))
                {
                    if (_logic.InsertOrderDetail(requestOrderDetail.list, orderCode))
                        return Ok("Insert Success");
                }

                return NotFound();

            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.Message + e.ToString());
            }
        }
    }
}