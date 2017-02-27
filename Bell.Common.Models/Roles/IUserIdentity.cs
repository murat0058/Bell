using System.Security.Principal;

namespace Bell.Common.Models.Roles
{
    /// <summary>
    /// Represents a user identity
    /// </summary>
    public class UserIdentity : IIdentity
    {
        #region Constructors

        /// <summary>
        /// Creates a user identity
        /// </summary>
        public UserIdentity(UserIdentifier user)
        {
            Details = user;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The authentication type
        /// </summary>
        public string AuthenticationType => "User";

        /// <summary>
        /// Indicates whether this identity is authenticated
        /// </summary>
        public bool IsAuthenticated => true;

        /// <summary>
        /// The name associated with the identity
        /// </summary>
        public string Name => Details.DisplayName;

        /// <summary>
        /// The user's details
        /// </summary>
        public UserIdentifier Details { get; }

        #endregion
    }
}
