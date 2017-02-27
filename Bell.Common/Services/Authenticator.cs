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
        /// <returns>The verify access token response</returns>
        Task<VerifyAccessTokenResponse> IsValidUserAccessTokenAsync(VerifyAccessTokenRequest request);
    }

    public class Authenticator : IAuthenticator
    {
        public async Task<VerifyAccessTokenResponse> IsValidUserAccessTokenAsync(VerifyAccessTokenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
