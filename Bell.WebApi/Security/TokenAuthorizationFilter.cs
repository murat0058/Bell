using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Bell.Common.Exceptions;
using Bell.Common.Resources;
using Bell.Common.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bell.WebApi.Security
{
    public class TokenAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthenticator _authenticator;

        public TokenAuthorizationFilter(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //if (!AllowAnonymousAccess(context))
            //{
            //    throw new UserReportableException(ErrorMessageKeys.ERROR_UNAUTHORIZED);
            //}

            //context.HttpContext.User = new ClaimsPrincipal();
            ///context.HttpContext.User

            //_authenticator.IsValidAccessTokenAsync(accessToken)
            //if (userToken == null)
            //{
            //    throw new UserReportableException(ErrorMessageKeys.ERROR_INVALID_ACCESS_TOKEN);
            //}

            //var user = await FindUserAsync(_userRepository.LoadAsync(userToken.UserId));

            //return user;


        }

        private bool AllowAnonymousAccess(AuthorizationFilterContext context)
        {
            bool allowAnonymousAccess = false;

           
            foreach (var filterDescriptor in context.ActionDescriptor.FilterDescriptors)
            {
                if (filterDescriptor.Filter is AllowAnonymousFilter)
                {
                    allowAnonymousAccess = true;
                    break;
                }
            }

            return allowAnonymousAccess;
        }
    }
}
