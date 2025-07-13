using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace Lab3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            // 1️⃣ Log the exception to a file
            var log = $"[{DateTime.Now}] Exception: {ex.Message}\nStackTrace: {ex.StackTrace}\n\n";
            File.AppendAllText("logs.txt", log);

            // 2️⃣ Return custom 500 error response
            var errorResponse = new
            {
                Message = "An unhandled error occurred.",
                ExceptionMessage = ex.Message,
                ExceptionType = ex.GetType().Name
            };

            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
