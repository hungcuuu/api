using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class CustomersController : BaseController
    {
        public CustomersController(IGuestLogic guestLogic) : base(guestLogic)
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
                PointOfSaleDBPassioContext db = new PointOfSaleDBPassioContext();
                var customer = db.Customer.ToList();
                
                return Ok(customer);

            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.Message + e.ToString());
            }
        }
    }
}