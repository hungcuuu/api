using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.BussinessLogics;
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
    
    public class AccountsController : BaseController
    {

        public AccountsController(IUserLogic userLogic, IOptions<Services> service) : base(userLogic)
        {
           
        }

        [AllowAnonymous]
        [HttpPost("login")]
        #region RepCode 200 400 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            Account user = new Account
            {
                AccountId = userLogin.id,
                AccountPassword = userLogin.password,
            };
            string response;

            //  Check For Bad Inputs
            if (user.AccountId == null || user.AccountPassword == null)
            {
                return BadRequest("Error : Can not get appropriate username or password ");
            }
            if (user.AccountId.Length <= 0 || user.AccountPassword.Length <= 0)
            {
                return BadRequest("Username and Password can not be empty");
            }

            //  Login. Response token string if succeed. Null if not found
            //  Returns exception when database is down.
            try
            {
                response = _userLogic.Login(user.AccountId,user.AccountPassword);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message+e.ToString());
            }


            if (response == null)
                return Unauthorized("Login Failed. Please check username or password");
            else
            {
                //Services.Value.sendMessageAsync();
                return Ok(response);
                
            }
               
        }

        [AllowAnonymous]
        [HttpPost]
        #region RepCode 200 400 404 500
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        #endregion
        public IActionResult InsertAccount([FromBody] Account account)
        {
            
            try
            {
                var rs = _userLogic.InsertAccount(account);
                if (!rs)
                    return BadRequest("Login Failed. Please check username or password");
                else
                    return Ok("Insert Success");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }
    }
}