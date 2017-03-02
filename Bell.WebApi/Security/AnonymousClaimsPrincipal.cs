using System.Security.Claims;

namespace Bell.WebApi.Security
{
    public class AnonymousClaimsPrincipal : ClaimsPrincipal
    {
        public AnonymousClaimsPrincipal() : base(new Identity(null, null, false))
        {
        }
    }
}
