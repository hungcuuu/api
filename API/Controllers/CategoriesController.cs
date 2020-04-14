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
    public class CategoriesController : BaseController
    {

        public CategoriesController(IGuestLogic guestLogic) : base(guestLogic)
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
        public IActionResult GetCategories()
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
        [HttpGet("{id}")]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetCategorysDetail(int id)
        {
            try
            {
                var table = _logic.GetCategoryDetail(id);
                if (table == null)
                    return NotFound();
                return Ok(table);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString());
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
        public IActionResult InsertCategory(Category category)
        {
            try
            {
                if (_logic.InsertCategory(category))
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
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                if (_logic.UpdateCategory(category))
                {

                    return Ok("Update Success");
                }
                else return NotFound();
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
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                if (_logic.DeleteCategory(id))
                {

                    return Ok("Delete Success");
                }
                else return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString());
            }
        }


    }
}