using Bell.Common.Models.Roles;

namespace Bell.Common.Models.Security
{
    /// <summary>
    /// Represents a response to verify the user access token
    /// </summary>
    public class VerifyUserAccessTokenResponse
    {
        /// <summary>
        /// Indicates whether the access token is valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// The user's information
        /// </summary>
        public User User { get; set; }
    }
}
