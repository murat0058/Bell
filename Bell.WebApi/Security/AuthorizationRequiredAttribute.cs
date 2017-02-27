using Bell.Common.Models.Security;
using Microsoft.AspNetCore.Mvc;

namespace Bell.WebApi.Security
{
    /// <summary>
    /// Authorization attribute
    /// </summary>
    public class AuthorizationRequiredAttribute : TypeFilterAttribute
    {
        #region Constructors

        public AuthorizationRequiredAttribute() : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { AuthorizationType.Any };
        }

        public AuthorizationRequiredAttribute(AuthorizationType authorizationType) : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { authorizationType };
        }

        #endregion
    }
}
