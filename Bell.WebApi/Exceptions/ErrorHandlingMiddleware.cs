using Bell.Common.Resources;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
                var reportableException = exception as UserReportableException;

                if (reportableException != null)
                {
                    code = HttpStatusCode.BadRequest;
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

        private async Task WriteExceptionAsync(HttpContext context, HttpStatusCode code, UserReportableException exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int) code;

            var error = await GenerateErrorAsync(exception);

            await response.WriteAsync(JsonConvert.SerializeObject(new { error }));
        }

        public async Task<dynamic> GenerateErrorAsync(UserReportableException exception)
        {
            dynamic error = new ExpandoObject();

            try
            {
                var errorMessages = await GenerateErrorMessagesAsync(exception);

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
                error.messages = new List<string> {"An error has occurred.  The error message(s) could not be translated."};
                error.details = e.Message;
                error.stackTrace = e.StackTrace;
            }

            return error;
        }

        public async Task<List<string>> GenerateErrorMessagesAsync(UserReportableException exception)
        {
            var errorMessages = new List<string>();

            // TODO: GET THE LANGUAGE ID HERE  
            foreach (var errorMessage in exception.ErrorMessages)
            {
                errorMessages.Add(await _translator.TranslateAsync("en-US", errorMessage.Key, errorMessage.Arguments));
            }

            return errorMessages;
        }

        #endregion
    }
}
