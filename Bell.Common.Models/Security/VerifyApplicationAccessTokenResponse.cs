using Bell.Common.Models.Environment;

namespace Bell.Common.Models.Security
{
    /// <summary>
    /// Represents a response to verify the user access token
    /// </summary>
    public class VerifyApplicationAccessTokenResponse
    {
        /// <summary>
        /// Indicates whether the access token is valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// The application's information
        /// </summary>
        public Application Application { get; set; }
    }
}
