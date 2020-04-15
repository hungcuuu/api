using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{

    public class TablesController : BaseController
    {


        public TablesController(IGuestLogic guestLogic) : base(guestLogic)
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
        public IActionResult GetTables()
        {
            try
            {
                var tables = _logic.GetTablesList();
                if (tables.Count == 0)
                    return NotFound("There are no Categories");

                return Ok(tables);
                //PointOfSaleDBPassioContext db = new PointOfSaleDBPassioContext();
                //  List<Category> result = db.Category.ToList();
                //  return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString());
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
        public IActionResult GetTableDetail(int id)
        {
            try
            {
                var table = _logic.GetTableDetail(id);
                if (table == null)
                    return NotFound("There are no tables");
                return Ok(table);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n ");
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
        public IActionResult InsertTable(Table table)
        {
            try
            {
                if (_logic.InsertTable(table))
                {

                    return Ok("Insert Success");
                }
                else return NotFound();
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
        public IActionResult UpdateTable(Table table)
        {
            try
            {
                if (_logic.UpdateTable(table))
                {
                    return Ok("Update Success");
                }
                else return NotFound("There are no tables");
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
        public IActionResult DeleteTable(int id)
        {
            try
            {
                if (_logic.DeleteTable(id))
                {

                    return Ok("Delete Success");
                }
                else return NotFound("There are no tables");
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString());
            }
        }
    }
}
