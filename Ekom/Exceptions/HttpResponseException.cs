using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

#if NETCOREAPP
namespace Ekom.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, object? value = null) =>
            (StatusCode, Value) = (statusCode, value);
        public HttpResponseException(HttpStatusCode statusCode, object? value = null) =>
            (StatusCode, Value) = ((int)statusCode, value);

        public int StatusCode { get; }

        public object? Value { get; }
    }

    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Value)
                {
                    StatusCode = httpResponseException.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
#endif
