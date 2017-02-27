using System.Linq;
using System.Security.Principal;
using Bell.Common.Exceptions;
using Bell.Common.Models.Security;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Bell.Common.Models.Roles;
using Bell.Common.Resources;

namespace Bell.WebApi.Security
{
    /// <summary>
    /// The authorization filter
    /// </summary>
    public class AuthorizationFilter : IAuthorizationFilter
    {
        #region Private Fields

        private readonly AuthorizationType _authorizationType;

        #endregion

        #region Constructors

        public AuthorizationFilter(AuthorizationType authorizationType)
        {
            _authorizationType = authorizationType;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Handles authorization
        /// </summary>
        /// <param name="context">The authorization context</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity;
            var allowAnonymous = context.Filters.Any(f => f is IAllowAnonymousFilter);

            var isAuthorized = allowAnonymous || IsAuthorized(identity);

            if (!isAuthorized)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_UNAUTHORIZED);
            }
        }

        #endregion

        #region Private Methods

        private bool IsAuthorized(IIdentity identity)
        {
            bool isAuthorized;

            switch (_authorizationType)
            {
                case AuthorizationType.Any:
                    isAuthorized = identity.IsAuthenticated;
                    break;

                case AuthorizationType.Application:
                    isAuthorized = identity is ApplicationIdentity;
                    break;

                case AuthorizationType.User:
                    isAuthorized = identity is UserIdentity;
                    break;

                default:
                    isAuthorized = false;
                    break;
            }

            return isAuthorized;
        }

        #endregion

    }
}
