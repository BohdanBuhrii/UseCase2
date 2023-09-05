using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace StripeAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class StripeController : ControllerBase
  {
    private readonly BalanceService _balanceService;
    private readonly BalanceTransactionService _balanceTransactionService;

    public StripeController(BalanceService balanceService, BalanceTransactionService balanceTransactionService)
    {
      _balanceService = balanceService;
      _balanceTransactionService = balanceTransactionService;
    }

    [HttpGet("balance")]
    public IActionResult GetBalance()
    {
      var balance = _balanceService.Get();
      return Ok(balance);
    }

    [HttpGet("balance-transactions")]
    public IActionResult GetBalanceTransactions(int limit = 10, string? startingAfter = null)
    {
      var options = new BalanceTransactionListOptions
      {
        Limit = limit,
        StartingAfter = startingAfter
      };

      var balanceTransactions = _balanceTransactionService.List(options);
      return Ok(balanceTransactions);
    }
  }
}
