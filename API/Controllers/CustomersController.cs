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

        //[AllowAnonymous]
        [HttpGet]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetCustomers()
        {
            try
            {
                var rs = _logic.GetCustomersList();
                if (rs.Count == 0)
                    return NotFound("There are no Customers");
                return Ok(rs);

            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.Message + e.ToString());
            }
        }

        [HttpGet("{id}")]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetCustomerDetail(int id)
        {
            try
            {
                var customer = _logic.GetCustomerDetail(id);
                if (customer == null)
                    return NotFound("There are no Customers");
                return Ok(customer);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString() + e.Message);
            }
        }



        [HttpPost]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult InsertCustomer(Customer customer)
        {
            try
            {
                if (_logic.InsertCustomer(customer))
                {

                    return Ok("Insert Success");
                }
                else return NotFound("There are no Customers");
            }
            catch (Exception)
            {
                return BadRequest("System Error:\n ");
            }
        }

        [HttpPut]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                if (_logic.UpdateCustomer(customer))
                {

                    return Ok("Update Success");
                }
                else return NotFound("There are no Customers");
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString());
            }
        }

        [HttpDelete]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                if (_logic.DeleteCustomer(id))
                {

                    return Ok("Delete Success");
                }
                else return NotFound("There are no Customers");
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString());
            }
        }
    }
}