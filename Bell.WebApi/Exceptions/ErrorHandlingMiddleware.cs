using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Bell.Common.Exceptions
{
    public class ErrorHandlingMiddleware
    {
        #region Private Fields

        private readonly RequestDelegate next;

        #endregion

        #region Constructors

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        #endregion

        #region Public Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        #endregion

        #region Private Methods

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;

            var code = HttpStatusCode.InternalServerError; 

            //if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
            //else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (exception is MyException) code = HttpStatusCode.BadRequest;

            await WriteExceptionAsync(context, code, exception).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, HttpStatusCode code, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = exception.Message,
                    exception = exception.GetType().Name
                }
            })).ConfigureAwait(false);
        }

        #endregion
    }
}
