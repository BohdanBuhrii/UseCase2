using Moq;
using StripeAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace StripeAPI.Tests
{
  public class StripeControllerTests
  {
    [Fact]
    public void GetBalance_ReturnsOkResult()
    {
      // Arrange
      var mockService = new Mock<BalanceService>();
      mockService.Setup(service => service.Get(It.IsAny<RequestOptions>()))
        .Returns(new Balance());

      var controller = new StripeController(mockService.Object, Mock.Of<BalanceTransactionService>());

      // Act
      var result = controller.GetBalance();

      // Assert
      Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetBalance_ThrowsStripeException()
    {
      // Arrange
      var mockService = new Mock<BalanceService>();
      mockService.Setup(service => service.Get(It.IsAny<RequestOptions>()))
        .Throws(new StripeException("Error occurred"));

      var controller = new StripeController(mockService.Object, Mock.Of<BalanceTransactionService>());

      // Act & Assert
      await Assert.ThrowsAsync<StripeException>(() => (Task)controller.GetBalance());
    }

    [Fact]
    public void GetBalanceTransactions_ReturnsOkResult()
    {
      // Arrange
      var mockService = new Mock<BalanceTransactionService>();
      mockService.Setup(service => service.List(It.IsAny<BalanceTransactionListOptions>(), It.IsAny<RequestOptions>()))
        .Returns(new StripeList<BalanceTransaction>());

      var controller = new StripeController(Mock.Of<BalanceService>(), mockService.Object);

      // Act
      var result = controller.GetBalanceTransactions();

      // Assert
      Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetBalanceTransactions_ThrowsStripeException()
    {
      // Arrange
      var mockService = new Mock<BalanceTransactionService>();
      mockService.Setup(service => service.List(It.IsAny<BalanceTransactionListOptions>(), It.IsAny<RequestOptions>()))
        .Throws(new StripeException("Error occurred"));

      var controller = new StripeController(Mock.Of<BalanceService>(), mockService.Object);

      // Act & Assert
      await Assert.ThrowsAsync<StripeException>(() => (Task)controller.GetBalanceTransactions());
    }
  }
}
