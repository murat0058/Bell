using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bell.WebApi.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public RedirectResult Index()
        {
            return Redirect("api-explorer");
        }
    }
}
