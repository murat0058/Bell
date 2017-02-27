namespace Bell.Common.Models.Security
{
    /// <summary>
    /// The user token request
    /// </summary>
    public class UserTokenRequest
    {
        #region Public Properties

        /// <summary>
        /// The user's e-mail address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's password
        /// </summary>
        public string Password { get; set; }

        #endregion
    }
}
