using System;
using System.Security.Claims;
using System.Threading.Tasks;
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

        #region Constructors

        public AuthenticationMiddleware(RequestDelegate next, IAuthenticator authenticator)
        {
            _next = next;
            _authenticator = authenticator;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Handles invoking each request
        /// </summary>
        /// <param name="context">The http context</param>
        /// <returns>An invocation task</returns>
        public async Task Invoke(HttpContext context)
        {
            StringValues authorizationValues;
            ClaimsPrincipal principal = new AnonymousClaimsPrincipal();

            if (context.Request.Headers.TryGetValue("Authorization", out authorizationValues))
            {
                if (authorizationValues.Count > 0)
                {
                    principal = await EvaluateAuthorizationAsync(authorizationValues[0]);
                }
            }

            context.User = principal;
            
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        #endregion

        #region Private Methods

        private async Task<ClaimsPrincipal> EvaluateAuthorizationAsync(string authorizationString)
        {
            ClaimsPrincipal principal = new AnonymousClaimsPrincipal();
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
                            principal = await AuthenticateApplicationIdentityAsync(token);
                            break;

                        case "User":
                            principal = await AuthenticateUserIdentityAsync(token);
                            break;
                    }
                }
            }

            return principal;
        }

        private async Task<ClaimsPrincipal> AuthenticateApplicationIdentityAsync(string token)
        {
            ClaimsPrincipal principal = new AnonymousClaimsPrincipal();

            var tokenRequest = new VerifyAccessTokenRequest { AccessToken = token };
            var response = await _authenticator.IsValidApplicationAccessTokenAsync(tokenRequest);

            if (response.IsValid)
            {
                principal = new ApplicationClaimsPrincipal(response.Application);
            }

            return principal;
        }

        private async Task<ClaimsPrincipal> AuthenticateUserIdentityAsync(string accessToken)
        {
            ClaimsPrincipal identity = new AnonymousClaimsPrincipal();

            var tokenRequest = new VerifyAccessTokenRequest {AccessToken = accessToken};
            var response = await _authenticator.IsValidUserAccessTokenAsync(tokenRequest);

            if (response.IsValid)
            {
                identity = new UserClaimsPrincipal(response.User);
            }

            return identity;
        }

        #endregion
    }
}

