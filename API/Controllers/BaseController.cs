using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Helpers;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        #region objects and constructors



        protected ClaimsIdentity identity;
      //  private readonly IUserLogic userLogic;
        protected readonly IGuestLogic _logic;
        //protected readonly IAdminLogic _adminLogic;
         protected readonly IUserLogic _userLogic;
        protected readonly IOptions<HelpPage> _helpPage;
        //protected readonly IOptions<IndexPage> _indexPage;
        protected readonly IOptions<AppSetting> _options;
        protected readonly IOptions<Services> _services;
        protected readonly IHttpContextAccessor _httpContext;

        public BaseController(IGuestLogic logic)
        {
            _logic = logic;
        }

        public BaseController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public BaseController(IUserLogic userLogic, IOptions<Services> services) : this(userLogic)
        {
            _services = services;
        }

        public BaseController(IGuestLogic logic, IOptions<HelpPage> helpPage) : this(logic)
        {
            _helpPage = helpPage;
        }

        //public BaseController(IGuestLogic logic)
        //{
        //    _logic = logic;
        //}
        //public BaseController(IGuestLogic guestLogic, IOptions<HelpPage> helpPage)
        //{
        //    _logic = guestLogic;
        //    _helpPage = helpPage;
        //}

        //public BaseController(IUserLogic userLogic, IOptions<HashMD5> hashMD5)
        //{
        //    _userLogic = userLogic;
        //    _hashMD5 = hashMD5;
        //}

        #endregion
    }
}