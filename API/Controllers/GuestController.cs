using System;
using BLL.Helpers;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    
    public class CategoriesController : BaseController
    {

        public CategoriesController(IGuestLogic guestLogic) : base(guestLogic)
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
        public IActionResult GetCategories()
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

    public class ProductsController : BaseController
    {


        public ProductsController(IGuestLogic guestLogic,
           IOptions<HelpPage> helpPage) : base(guestLogic, helpPage)
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
                var categories = _logic.GetProductDetail(id);

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
                var categories = _logic.GetProductsByCategory(catId);
                if (categories.Count == 0)
                    return NotFound("There are no Products");

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