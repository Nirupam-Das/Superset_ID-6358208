// Filters/CustomAuthFilter.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab3.Filters;

/// <summary>
/// Simple “poor‑man’s” auth filter:
///   • Looks for an Authorization header
///   • Ensures it contains the word “Bearer”
///   • Otherwise short‑circuits with 400 Bad Request
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // 1️⃣ Does the header exist?
        if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
        {
            context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
            return; // stop the pipeline
        }

        // 2️⃣ Does it contain the keyword “Bearer”?
        if (!token.ToString().Contains("Bearer", StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
            return;
        }

        // otherwise continue to the controller
        base.OnActionExecuting(context);
    }
}
