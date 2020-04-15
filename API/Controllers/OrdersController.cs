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
        public IActionResult GetOrders()
        {
            try
            {
                var categories = _logic.GetCategoriesList();
                if (categories.Count == 0)
                    return NotFound("There are no Categories");

                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.Message + e.ToString());
            }
        }
        [AllowAnonymous]
        [HttpPost]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetPayment(MoMoRequest moMoRequest)
        {
            try
            {
                PointOfSaleDBPassioContext db = new PointOfSaleDBPassioContext();
                if(moMoRequest.status==0)
                {
                    var customer = new Customer { Email = "ahjhj" };
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    return Ok();
                }

                return BadRequest();
                    
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.Message + e.ToString());
            }
        }

    }
}