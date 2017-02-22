using System;
using System.Threading.Tasks;
using Bell.Common.Models;

namespace Bell.Common.Services
{
    public interface IAuthenticator
    {
        /// <summary>
        /// Verifies the acces token and finds the user associated with the access token or throws an error if the token has expired
        /// </summary>
        /// <param name="accessToken">The access token</param>
        /// <returns>The user's information</returns>
        Task<User> VerifyAccessToken(string accessToken);
    }

    public class Authenticator : IAuthenticator
    {
        public async Task<User> VerifyAccessToken(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
