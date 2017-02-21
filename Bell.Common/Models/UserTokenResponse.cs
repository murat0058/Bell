using System;

namespace Bell.Common.Models
{
    public class UserTokenResponse
    {
        #region Public Properties

        /// <summary>
        /// The user's access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The expiration date/time of the API token
        /// </summary>
        public DateTime ExpirationDateTime { get; set; }

        /// <summary>
        /// The user's refresh token
        /// </summary>
        /// <remarks>Used to generate a new API token</remarks>
        public string RefreshToken { get; set; }

        /// <summary>
        /// The user's information
        /// </summary>
        public User User { get; set; }

        #endregion
    }
}
