namespace Bell.Common.Models.Security
{
    /// <summary>
    /// The refresh token request
    /// </summary>
    public class RefreshTokenRequest
    {
        #region Public Properties

        /// <summary>
        /// The user's e-mail address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's refresh token
        /// </summary>
        public string RefreshToken { get; set; }

        #endregion
    }
}
