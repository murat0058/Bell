using System.Security.Principal;

namespace Bell.Common.Models.Roles
{
    /// <summary>
    /// Represents an anonymous identity
    /// </summary>
    public class AnonymousIdentity : IIdentity
    {
        #region Public Properties

        /// <summary>
        /// The authentication type
        /// </summary>
        public string AuthenticationType => null;

        /// <summary>
        /// Indicates whether this identity is authenticated
        /// </summary>
        public bool IsAuthenticated => false;

        /// <summary>
        /// The name associated with the identity
        /// </summary>
        public string Name => null;

        #endregion
    }
}
