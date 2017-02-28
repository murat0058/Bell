namespace Bell.Common.Models.Security
{
    /// <summary>
    /// Represents a verify access token request
    /// </summary>
    public class VerifyApplicationAccessTokenRequest
    {
        /// <summary>
        /// The universal application id
        /// </summary>
        public string UniversalApplicationId { get; set; }

        /// <summary>
        /// The application's access token
        /// </summary>
        public string AccessToken { get; set; }
    }
}
