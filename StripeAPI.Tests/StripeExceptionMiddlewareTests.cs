using Microsoft.AspNetCore.Http;
using StripeAPI.Middlewares;
using Stripe;

namespace StripeAPI.Tests
{
  public class StripeExceptionMiddlewareTests
  {
    [Fact]
    public async Task InvokeAsync_StripeExceptionRaised_ReturnsBadRequest()
    {
      // Arrange
      var middleware = new StripeExceptionMiddleware(innerHttpContext => throw new StripeException("Error occurred"));

      var context = new DefaultHttpContext();
      context.Response.Body = new MemoryStream();

      // Act
      await middleware.InvokeAsync(context);
      context.Response.Body.Seek(0, SeekOrigin.Begin);
      var reader = new StreamReader(context.Response.Body);
      var text = await reader.ReadToEndAsync();

      // Assert
      Assert.Contains("Error occurred", text);
      Assert.Equal(StatusCodes.Status400BadRequest, context.Response.StatusCode);
    }

    [Fact]
    public async Task InvokeAsync_OtherExceptionRaised_PropagatesException()
    {
      // Arrange
      var middleware = new StripeExceptionMiddleware(innerHttpContext => throw new Exception("Non-stripe exception"));

      var context = new DefaultHttpContext();

      // Act & Assert
      await Assert.ThrowsAsync<Exception>(() => middleware.InvokeAsync(context));
    }
  }
}
