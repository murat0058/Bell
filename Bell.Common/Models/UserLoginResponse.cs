namespace Bell.Common.Models
{
    public class UserLoginResponse
    {
        #region Public Properties

        /// <summary>
        /// The user's API token
        /// </summary>
        public string ApiToken { get; set; }

        /// <summary>
        /// The user's information
        /// </summary>
        public User User { get; set; }

        #endregion
    }
}
