﻿using System.Security.Principal;

namespace Bell.Common.Models.Roles
{
    /// <summary>
    /// Represents an application identity
    /// </summary>
    public class ApplicationIdentity : IIdentity
    {
        #region Constructors

        /// <summary>
        /// Creates an application identity
        /// </summary>
        public ApplicationIdentity(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The authentication type
        /// </summary>
        public string AuthenticationType => "Application";

        /// <summary>
        /// Indicates whether this identity is authenticated
        /// </summary>
        public bool IsAuthenticated => true;

        /// <summary>
        /// The name associated with the identity
        /// </summary>
        public string Name { get; }

        #endregion
    }
}
