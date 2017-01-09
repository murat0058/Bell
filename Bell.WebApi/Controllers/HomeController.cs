using Microsoft.AspNetCore.Mvc;

namespace Bell.Common.WebApi.Controllers
{
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
