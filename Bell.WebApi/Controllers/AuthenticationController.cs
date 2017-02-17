using Microsoft.AspNetCore.Mvc;

namespace Bell.WebApi.Controllers
{
    /// <summary>
    /// Authentication Services
    /// </summary>
    [Route("api/authentication")]
    public class AuthenticationController: Controller
    {
        [HttpGet("user/login")]
        public string UserLoginAsync()
        {
            return "login!";
        }
    }
}
