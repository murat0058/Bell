using System;
using System.Threading.Tasks;
using Bell.Common.Models;

namespace Bell.Common.Services
{
    public interface IAuthenticator
    {
        /// <summary>
        /// Creates an API token via user credentials
        /// </summary>
        /// <param name="userTokenRequest">The user token request</param>
        /// <param name="ipAddress">The ip address of the machine requesting the token</param>
        /// <returns>A user token response</returns>
        Task<UserTokenResponse> CreateTokenAsync(UserTokenRequest userTokenRequest, string ipAddress);

        /// <summary>
        /// Verifies the acces token and finds the user associated with the access token or throws an error if the token has expired
        /// </summary>
        /// <param name="accessToken">The access token</param>
        /// <returns>The user's information</returns>
        Task<User> VerifyAccessToken(string accessToken);

        /// <summary>
        /// Refreshes the API token
        /// </summary>
        /// <param name="refreshTokenRequest">The refresh token request data</param>
        /// <param name="ipAddress">The ip address of the machine requesting the token</param>
        /// <returns>The refresh token response</returns>
        Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest, string ipAddress);
    }

    public class Authenticator : IAuthenticator
    {
        public async Task<UserTokenResponse> CreateTokenAsync(UserTokenRequest userTokenRequest, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<User> VerifyAccessToken(string accessToken)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest, string ipAddress)
        {
            throw new NotImplementedException();
        }
    }
}
