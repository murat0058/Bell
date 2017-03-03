using Bell.Common.Resources;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bell.Common.Configuration;
using Bell.Common.Exceptions;
using Bell.Common.Models.Exceptions;
using Bell.Common.Services;
using Bell.WebApi.Security;
using Newtonsoft.Json.Serialization;

namespace Bell.WebApi.Exceptions
{
    public class ErrorHandlingMiddleware
    {
        #region Private Fields

        private readonly RequestDelegate _next;

        private readonly IApplicationSettings _settings;
        private readonly ILog _log;
        private readonly ILanguageTranslator _translator;

        #endregion

        #region Constructors

        public ErrorHandlingMiddleware(RequestDelegate next, IApplicationSettings settings, ILog log, ILanguageTranslator translator)
        {
            _next = next;
            _settings = settings;
            _log = log;
            _translator = translator;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Handles invoking each request
        /// </summary>
        /// <param name="context">The http context</param>
        /// <returns>An invocation task</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Call the next deletegate/middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        #endregion

        #region Private Methods

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            if (exception != null)
            {
                UserReportableException userReportableException;
                var reportableException = exception as UserReportableException;

                if (reportableException != null)
                {
                    code = FindErrorCode(reportableException);
                    userReportableException = reportableException;
                }
                else
                {
                    var userReportableMessage = new UserReportableMessage(ErrorMessageKeys.ERROR_HAS_OCCURRED);
                    userReportableException = new UserReportableException(exception, userReportableMessage);

                    try
                    {
                        _log.Error(exception, await _translator.TranslateAsync("en-US", userReportableMessage.Key));
                    }
                    catch
                    {
                        userReportableException.ErrorMessages.Add(new UserReportableMessage(ErrorMessageKeys.ERROR_LOGGING));
                    }

                }
                
                await WriteExceptionAsync(context, code, userReportableException);
            }
        }

        private HttpStatusCode FindErrorCode(UserReportableException exception)
        {
            return exception.PrimaryErrorMessageKey == ErrorMessageKeys.ERROR_UNAUTHORIZED
                ? HttpStatusCode.Unauthorized
                : HttpStatusCode.BadRequest;
        }

        private async Task WriteExceptionAsync(HttpContext context, HttpStatusCode code, UserReportableException exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int) code;

            var error = await GenerateErrorAsync(context, exception);
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            await response.WriteAsync(JsonConvert.SerializeObject(new { error }, serializerSettings));
        }

        public async Task<dynamic> GenerateErrorAsync(HttpContext context, UserReportableException exception)
        {
            dynamic error = new ExpandoObject();

            try
            {
                var errorMessages = await GenerateErrorMessagesAsync(context, exception);

                error.code = exception.ErrorMessages[0].Key;
                error.messages = errorMessages;
                error.details = exception.Message;
                error.stackTrace = exception.StackTrace;

                if (exception.InnerException != null)
                {
                    error.details = exception.InnerException.Message;
                    error.stackTrace = exception.InnerException.StackTrace;
                }
            }
            catch (Exception e)
            {
                error.code = ErrorMessageKeys.ERROR_HAS_OCCURRED;
                error.messages = new List<string> { "An error has occurred.  The error message(s) could not be translated." };
                error.details = e.Message;
                error.stackTrace = e.StackTrace;
            }

            if (!_settings.IsDevelopment())
            {
                var errorDictionary = (IDictionary<string, object>)error;
                errorDictionary.Remove("details");
                errorDictionary.Remove("stackTrace");
            }

            return error;
        }

        public async Task<List<string>> GenerateErrorMessagesAsync(HttpContext context, UserReportableException exception)
        {
            var errorMessages = new List<string>();
            var languageId = await FindUserLanguageAsync(context);

            foreach (var errorMessage in exception.ErrorMessages)
            {
                errorMessages.Add(await _translator.TranslateAsync(languageId, errorMessage.Key, errorMessage.Arguments));
            }

            return errorMessages;
        }

        private async Task<string> FindUserLanguageAsync(HttpContext context)
        {
            var userPrincipal = context.User as UserClaimsPrincipal;

            string userLanguageId = (userPrincipal != null)
                ? userPrincipal.User.LanguageId
                : FindUserLanguageFromHeader(context);

            var supportedLanguages = await _translator.FindSupportedLanguagesAsync();

            if (!supportedLanguages.Contains(userLanguageId))
            {
                userLanguageId = _translator.DefaultLanguageId;
            }

            return userLanguageId;
        }

        private string FindUserLanguageFromHeader(HttpContext context)
        {
            var userLanguageId = _translator.DefaultLanguageId;
            var headers = context.Request.GetTypedHeaders();
            var languages = headers.AcceptLanguage;

            if (languages != null && languages.Count > 0)
            {
                userLanguageId = languages[0].Value;
            }

            return userLanguageId;
        }

        #endregion
    }
}
