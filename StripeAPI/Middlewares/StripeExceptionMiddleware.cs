using Stripe;

namespace StripeAPI.Middlewares
{
  public class StripeExceptionMiddleware
  {
    private readonly RequestDelegate _next;

    public StripeExceptionMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (StripeException ex)
      {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        var text = new { error = ex.Message }.ToString() ?? string.Empty;
        await httpContext.Response.WriteAsync(text);
      }
    }
  }
}
