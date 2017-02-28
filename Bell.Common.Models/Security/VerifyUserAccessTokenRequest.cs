namespace Bell.Common.Models.Security
{
    /// <summary>
    /// Represents a verify access token request
    /// </summary>
    public class VerifyUserAccessTokenRequest
    {
        /// <summary>
        /// The access token
        /// </summary>
        public string AccessToken { get; set; }
    }
}
