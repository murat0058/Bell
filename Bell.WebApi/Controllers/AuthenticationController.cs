using System.Threading.Tasks;
using Bell.Common.Models;
using Bell.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bell.WebApi.Controllers
{
    /// <summary>
    /// Authentication Services
    /// </summary>
    [Route("api/authentication")]
    public class AuthenticationController: Controller
    {
        #region Private Fields

        private readonly IAuthenticator _authenticator;

        #endregion

        #region Constructors

        public AuthenticationController(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the API token based on user login credentials
        /// </summary>
        /// <param name="userTokenRequest">The user token request</param>
        /// <returns>The user token response</returns>
        [HttpPost("user/token")] 
        public async Task<UserTokenResponse> CreateUserTokenAsync([FromBody] UserTokenRequest userTokenRequest)
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            return await _authenticator.CreateTokenAsync(userTokenRequest, ipAddress.ToString());
        }

        #endregion
    }
}
