using System;
using Bell.Common.Models.Roles;

namespace Bell.Common.Models.Security
{
    /// <summary>
    /// The refresh token response
    /// </summary>
    public class RefreshTokenResponse
    {
        #region Public Properties

        /// <summary>
        /// The new access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The expiration date/time of this new API token
        /// </summary>
        public DateTime ExpirationDateTime { get; set; }

        /// <summary>
        /// The user's information
        /// </summary>
        public User User { get; set; }

        #endregion
    }
}
