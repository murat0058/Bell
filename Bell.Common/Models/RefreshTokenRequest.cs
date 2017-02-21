namespace Bell.Common.Models
{
    /// <summary>
    /// The refresh token request
    /// </summary>
    public class RefreshTokenRequest
    {
        #region Public Properties

        /// <summary>
        /// The user's id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// The user's refresh token
        /// </summary>
        public string RefreshToken { get; set; }

        #endregion
    }
}
