using System;
using System.Threading.Tasks;
using Bell.Common.Models.Security;

namespace Bell.Common.Services
{
    public interface IAuthenticator
    {
        /// <summary>
        /// Checks to see if the user access token is valid
        /// </summary>
        /// <param name="request">The access token request</param>
        /// <returns>A response indicating if it is valid and if so, includes user information</returns>
        Task<VerifyUserAccessTokenResponse> IsValidUserAccessTokenAsync(VerifyUserAccessTokenRequest request);

        /// <summary>
        /// Checks to see if the application access token is valid
        /// </summary>
        /// <param name="request">The access token request</param>
        /// <returns>A response indicating if it is valid and if so, includes application information</returns>
        Task<VerifyApplicationAccessTokenResponse> IsValidApplicationAccessTokenAsync(VerifyApplicationAccessTokenRequest request);
    }

    public class Authenticator : IAuthenticator
    {
        public async Task<VerifyUserAccessTokenResponse> IsValidUserAccessTokenAsync(VerifyUserAccessTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<VerifyApplicationAccessTokenResponse> IsValidApplicationAccessTokenAsync(VerifyApplicationAccessTokenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
