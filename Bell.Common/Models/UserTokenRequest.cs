namespace Bell.Common.Models
{
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
