using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using BLL.Interfaces;

namespace API.Controllers
{
   
    public class TablesController : BaseController
    {
        

        public TablesController(IGuestLogic guestLogic) : base(guestLogic)
        {
        }

        [HttpGet]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetTables()
        {
            try
            {
                var categories = _logic.GetCategoriesList();
                if (categories.Count == 0)
                    return NotFound("There are no Categories");

                return Ok(categories);
                //PointOfSaleDBPassioContext db = new PointOfSaleDBPassioContext();
                //  List<Category> result = db.Category.ToList();
                //  return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n ");
            }
        }
    }
}
