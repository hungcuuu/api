using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.RequestModels;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {


        public ProductsController(IGuestLogic guestLogic,
           IOptions<HelpPage> helpPage) : base(guestLogic, helpPage)
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
        public IActionResult GetProducts()
        {
            try
            {
                var products = _logic.GetProductsList();
                if (products.Count == 0)
                    return NotFound("There are no Products");
                var result = new
                {
                    products.Count,
                    products,
                };
                return Ok(result);
                //PointOfSaleDBPassioContext db = new PointOfSaleDBPassioContext();
                //  List<Category> result = db.Category.ToList();
                //  return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString() + e.Message);
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
        public IActionResult GetProductDetail(int id)
        {
            try
            {
                var product = _logic.GetProductDetail(id);
                if (product == null)
                    return NotFound("There are no Products");
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString() + e.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet("search")]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetProductsBySearchName(string search,int pageItems,int currentPage)
        {
            try
            {
                var product = _logic.GetProductsSearchList(search,pageItems,currentPage);
                if (product == null)
                    return NotFound("There are no Products");
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest("System Error:\n " + e.ToString() + e.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet("categories")]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult GetProductsByCategory(int catId)
        {
            try
            {
                var products = _logic.GetProductsByCategory(catId);
                if (products.Count == 0)
                    return NotFound("There are no Products");

                return Ok(products);
            }
            catch (Exception )
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
        public IActionResult InsertProduct(Product product)
        {
            try
            {
                if (_logic.InsertProduct(product))
                {

                    return Ok("Insert Success");
                }
                else return NotFound("There are no Products");
            }
            catch (Exception)
            {
                return BadRequest("System Error:\n ");
            }
        }
        [HttpPut("img")]
        #region RepCode 200 400 401 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult UpdateImageProduct(ImageRequest imageRequest)
        {
            try
            {
                if (_logic.UpdateImageProduct(imageRequest.id, imageRequest.url))
                {

                    return Ok("Insert Success");
                }
                else return NotFound("There are no Products");
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
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                if (_logic.UpdateProduct(product))
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