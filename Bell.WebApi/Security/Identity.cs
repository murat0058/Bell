using System.Security.Principal;

namespace Bell.WebApi.Security
{
    /// <summary>
    /// Represents an identity
    /// </summary>
    public class Identity : IIdentity
    {
        #region Constructors

        /// <summary>
        /// Creates an identity
        /// </summary>
        public Identity(string authenticationType, string name, bool isAuthenticated)
        {
            AuthenticationType = authenticationType;
            Name = name;
            IsAuthenticated = isAuthenticated;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The authentication type
        /// </summary>
        public string AuthenticationType { get; }

        /// <summary>
        /// The name of the identity
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Indicates if the identity is authenticated
        /// </summary>
        public bool IsAuthenticated { get; }

        #endregion
    }
}
