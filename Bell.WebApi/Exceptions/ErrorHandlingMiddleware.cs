using Bell.Common.Resources;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Bell.Common.Exceptions;
using Bell.Common.Services;

namespace Bell.WebApi.Exceptions
{
    public class ErrorHandlingMiddleware
    {
        #region Private Fields

        private readonly RequestDelegate _next;
        private readonly ILog _log;
        private readonly ILanguageTranslator _translator; 

        #endregion

        #region Constructors

        public ErrorHandlingMiddleware(RequestDelegate next, ILog log, ILanguageTranslator translator)
        {
            _next = next;
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

                if (exception is UserReportableException)
                {
                    code = HttpStatusCode.BadRequest;
                    userReportableException = (UserReportableException)exception;
                }
                else
                {
                    var userReportableMessage = new UserReportableMessage(ErrorMessageKeys.ERROR_HAS_OCCURRED);
                    userReportableException = new UserReportableException(exception, userReportableMessage);

                    _log.Error(exception, await _translator.TranslateAsync("en-US", userReportableMessage.Key));
                }
                
                await WriteExceptionAsync(context, code, userReportableException);
            }
        }

        private async Task WriteExceptionAsync(HttpContext context, HttpStatusCode code,
            UserReportableException exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int) code;

            string errorMessage;

            try
            {
                // TODO: GET THE LANGUAGE ID HERE  
                errorMessage =
                    await _translator.TranslateAsync("en-US", exception.ErrorMessage.Key, exception.ErrorMessage.Arguments);
            }
            catch (Exception e)
            {
                exception = new UserReportableException(e,
                    new UserReportableMessage(ErrorMessageKeys.ERROR_HAS_OCCURRED));
                errorMessage = "An error has occurred.  The error message could not be translated.";
            }

            var exceptionMessage = exception.Message;
            var stackTrace = exception.StackTrace;

            if (exception.ErrorMessage.Key == ErrorMessageKeys.ERROR_HAS_OCCURRED &&
                exception.InnerException != null)
            {
                exceptionMessage = exception.InnerException.Message;
                stackTrace = exception.InnerException.StackTrace;
            }

            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = new
                {
                    code = exception.ErrorMessage.Key,
                    message = errorMessage,
                    exception = exceptionMessage,
                    stackTrace = stackTrace
                }
            }));
        }

        #endregion
    }
}
