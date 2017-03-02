using System.Security.Claims;
using Bell.Common.Models.Environment;

namespace Bell.WebApi.Security
{
    /// <summary>
    /// An application claims principal
    /// </summary>
    public class ApplicationClaimsPrincipal : ClaimsPrincipal
    {
        #region Constructor

        /// <summary>
        /// Constructs an application claims principal
        /// </summary>
        public ApplicationClaimsPrincipal(Application application)
            : base(new Identity("Application", application.Name, true))
        {
            Application = application;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The application information
        /// </summary>
        public Application Application { get; }

        #endregion
    }
}
