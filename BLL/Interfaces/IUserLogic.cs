using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserLogic
    {
        public string Login(string userid, string password);
        //   public Account LoginFirebase(string token);
        public bool InsertAccount(Account account);
    }
}
