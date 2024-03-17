using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace lab07_3.Models
{
    public class AccountModel
    {
        private LoginLibraryDataContext context = null;

        public AccountModel()
        {
            context = new LoginLibraryDataContext();

        }

        public bool Login(string Email, string Password)
        {
            bool? res = false;
            context.sp_Account_Login_Check2(Email, Password, ref res);
            return (res ?? false);
        }
    }
}