using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bell.Common.Models;
using Bell.Common.Services;

namespace Bell.Common.Services
{
    public interface IUserLoginService
    { 
        UserLoginResponse Login(string username, string password);
    }

    public class UserLoginService : IUserLoginService
    {
    }
}
