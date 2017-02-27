namespace Bell.Common.Models.Security
{
    /// <summary>
    /// Represents a verify access token request
    /// </summary>
    public class VerifyAccessTokenResponse
    {
        /// <summary>
        /// Indicates whether the access token is valid
        /// </summary>
        public bool IsValid { get; set; }
    }
}
