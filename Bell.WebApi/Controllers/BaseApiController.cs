using Bell.Common.Models.Environment;
using Bell.Common.Models.Roles;
using Bell.WebApi.Security;
using Microsoft.AspNetCore.Mvc;

namespace Bell.WebApi.Controllers
{
    public class BaseApiController : Controller
    {
        /// <summary>
        /// The application information (when an application is requesting data)
        /// </summary>
        public Application Application
        {
            get
            {
                Application application = null;
                var applicationClaimsPrincipal = User as ApplicationClaimsPrincipal;

                if (applicationClaimsPrincipal != null)
                {
                    application = applicationClaimsPrincipal.Application;
                }

                return application;
            }
        }

        /// <summary>
        /// The current user information (when a user is requesting data)
        /// </summary>
        public User CurrentUser
        {
            get
            {
                User user = null;
                var userClaimsPrincipal = User as UserClaimsPrincipal;

                if (userClaimsPrincipal != null)
                {
                    user = userClaimsPrincipal.User;
                }

                return user;
            }
        }

    }
}
