using System.ComponentModel.DataAnnotations;
using System.Net;
using GameApi.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace GameApi.Configurations
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ErrorDetails errorDetails = new ErrorDetails();

            if (exception is NotFoundException)
            {
                errorDetails.StatusCode = (int) HttpStatusCode.NotFound;
                errorDetails.Message = "Entity was not found.";
                errorDetails.ExceptionMessage = exception.Message;
            }
            else if (exception is InvalidInput)
            {
                errorDetails.StatusCode = (int) HttpStatusCode.BadRequest;
                errorDetails.Message = GenerateInvalidInputMessage((InvalidInput) exception);
                errorDetails.ExceptionMessage = exception.Message;
            }
            else
            {
                errorDetails.StatusCode = (int) HttpStatusCode.InternalServerError;
                errorDetails.Message = "An unexpected error occurred.";
                errorDetails.ExceptionMessage = exception.Message;
            }

            //set the status coded of the http response and the content type of the http response
            httpContext.Response.StatusCode = errorDetails.StatusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(errorDetails, cancellationToken);

            return true;
        }

        private string GenerateInvalidInputMessage(InvalidInput exception)
        {
            string message = exception.Message;

            List<string> errors = exception.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            message += string.Join(", ", errors);

            return message;
        }
    }
}