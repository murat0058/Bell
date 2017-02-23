using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bell.Common.Resources;
using Bell.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bell.WebApi.Filters
{
    public class TokenAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthenticator _authenticator;
        private readonly ILanguageTranslator _translator;

        public TokenAuthorizationFilter(IAuthenticator authenticator, ILanguageTranslator translator)
        {
            _authenticator = authenticator;
            _translator = translator;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!AllowAnonymousAccess(context))
            {
                context.Result = await BuildUnauthorizedResultAsync(context);
            }
        }

        private bool AllowAnonymousAccess(AuthorizationFilterContext context)
        {
            bool allowAnonymousAccess = false;

            foreach (var filterDescriptor in context.ActionDescriptor.FilterDescriptors)
            {
                if (filterDescriptor.Filter is AllowAnonymousFilter)
                {
                    allowAnonymousAccess = true;
                    break;
                }
            }

            return allowAnonymousAccess;
        }

        private async Task<IActionResult> BuildUnauthorizedResultAsync(AuthorizationFilterContext context)
        {
            var languageId = await FindUserLanguageAsync(context.HttpContext.Request);
            var unauthorizedResult = new JsonResult(new
            {
                code = ErrorMessageKeys.ERROR_UNAUTHORIZED,
                message = await _translator.TranslateAsync(languageId, ErrorMessageKeys.ERROR_UNAUTHORIZED)
            });

            unauthorizedResult.StatusCode = (int)HttpStatusCode.Unauthorized;

            return unauthorizedResult;
        }

        private async Task<string> FindUserLanguageAsync(HttpRequest request)
        {
            var userLanguageId = _translator.DefaultLanguageId;

            var headers = request.GetTypedHeaders();
            var languages = headers.AcceptLanguage;

            if (languages != null && languages.Count > 0)
            {
                userLanguageId = languages[0].Value;

                var supportedLanguages = await
                    _translator.FindSupportedLanguagesAsync();

                if (!supportedLanguages.Contains(userLanguageId))
                {
                    userLanguageId = _translator.DefaultLanguageId;
                }
            }
          
            return userLanguageId;
        }
    }
}
