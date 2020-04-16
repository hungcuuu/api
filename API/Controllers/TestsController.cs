using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class TestsController : BaseController
    {
        public TestsController(IGuestLogic guestLogic) : base(guestLogic)
        {
        }
        [HttpPost]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult InsertCategory(List<ProductOrder> category)
        {
            try
            {
                

                    return Ok("Insert Success");
                
            }
            catch (Exception)
            {
                return BadRequest("System Error:\n ");
            }
        }
    }
}