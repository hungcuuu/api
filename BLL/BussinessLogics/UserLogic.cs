using BLL.Helpers;
using BLL.Interfaces;
using DAL.Models;
using DAL.UnitOfWorks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BLL.BussinessLogics
{
    public class UserLogic : IUserLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly AppSetting _appSetting;
        private readonly Services _services;
        public UserLogic(IOptions<AppSetting> appSetting, IUnitOfWork uow, Services services)
        {
            _services = services;
            _uow = uow;
            _appSetting = appSetting.Value;
        }


        public string Login(string userid, string password)
        {

            var hashPassword = _services.GetMd5Hash(password);
            var User = _uow.GetRepository<Account>().GetAll()
                .FirstOrDefault(user => user.AccountId == userid && user.AccountPassword == hashPassword);

            if (User == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, User.AccountId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            _services.sendMessageAsync();
            return tokenString;
        }
        public bool InsertAccount(Account account)
        {
            try
            {
                var hashPassword = _services.GetMd5Hash(account.AccountPassword);
                account.AccountPassword = hashPassword;
                _uow.GetRepository<Account>().Insert(account);
                var rs = _uow.Commit() > 0 ? true : false;
                return rs;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public Account LoginFirebase(string token)
        //{
        //    var stream = token;
        //    var handler = new JwtSecurityTokenHandler();
        //    var jsonToken = handler.ReadToken(stream);
        //    var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

        //    var userid = tokenS.Claims.First(claim => claim.Type == "sub").Value;
        //    var name = tokenS.Claims.First(claim => claim.Type == "name").Value;
        //    var email = tokenS.Claims.First(claim => claim.Type == "email").Value;
        //    var temp = _uow.GetRepository<Account>().GetAll().FirstOrDefault(c => c.AccountId.Equals(userid));
        //    if (temp == null)
        //    {
        //        _uow.GetRepository<Customer>().Insert(new Customer
        //        {
        //            UserId = userid,
        //            Password = "password",
        //            RoleId = 1,
        //            Email = email,
        //            UserName = name
        //        });
        //        _uow.SaveChange();
        //    }

        //    return Login(userid, "password");
        //}

        
    }

}
