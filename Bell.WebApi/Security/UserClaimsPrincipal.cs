using System.Security.Claims;
using Bell.Common.Models.Roles;

namespace Bell.WebApi.Security
{
    /// <summary>
    /// A user claims principal
    /// </summary>
    public class UserClaimsPrincipal : ClaimsPrincipal
    {
        #region Constructor

        /// <summary>
        /// Constructs an application claims principal
        /// </summary>
        public UserClaimsPrincipal(User user)
            : base(new Identity("User", $"{user.FirstName} {user.LastName}", true))
        {
            User = user;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The user's information
        /// </summary>
        public User User { get; }

        #endregion
    }
}
