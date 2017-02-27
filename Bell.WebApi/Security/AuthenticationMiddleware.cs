using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Bell.Common.Models.Roles;
using Bell.Common.Models.Security;
using Bell.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Bell.WebApi.Security
{
    public class AuthenticationMiddleware
    {
        #region Private Fields

        private readonly RequestDelegate _next;
        private readonly IAuthenticator _authenticator;

        #endregion

        public AuthenticationMiddleware(RequestDelegate next, IAuthenticator authenticator)
        {
            _next = next;
            _authenticator = authenticator;
        }

        /// <summary>
        /// Handles invoking each request
        /// </summary>
        /// <param name="context">The http context</param>
        /// <returns>An invocation task</returns>
        public async Task Invoke(HttpContext context)
        {
            StringValues authorizationValues;
            IIdentity identity = new AnonymousIdentity();

            if (context.Request.Headers.TryGetValue("Authorization", out authorizationValues))
            {
                if (authorizationValues.Count > 0)
                {
                    identity = await EvaluateAuthorizationAsync(authorizationValues[0]);
                }
            }

            context.User = new ClaimsPrincipal(identity);

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        private async Task<IIdentity> EvaluateAuthorizationAsync(string authorizationString)
        {
            IIdentity identity = new AnonymousIdentity();
            var authParts = authorizationString.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            if (authParts.Length == 2)
            {
                var scheme = authParts[0];
                var token = authParts[1];

                if (!string.IsNullOrWhiteSpace(token))
                {
                    switch (scheme)
                    {
                        case "Application":
                            identity = await AuthenticateApplicationIdentityAsync(token);
                            break;

                        case "User":
                            identity = await AuthenticateUserIdentityAsync(token);
                            break;
                    }
                }
            }

            return identity;
        }

        private async Task<IIdentity> AuthenticateApplicationIdentityAsync(string token)
        {
            IIdentity identity = new AnonymousIdentity();

            // TODO: Validate Application Identity
            b

            return identity;
        }

        private async Task<IIdentity> AuthenticateUserIdentityAsync(string accessToken)
        {
            IIdentity identity = new AnonymousIdentity();
            var tokenRequest = new VerifyAccessTokenRequest {AccessToken = accessToken};

            if ((await _authenticator.IsValidUserAccessTokenAsync(tokenRequest)).IsValid)
            {
                UserIdentifier userIdentifier = new UserIdentifier(); // TODO: Replace with user fetching logic
                b
                identity = new UserIdentity(userIdentifier);
            }

            return identity;
        }

    }
}

