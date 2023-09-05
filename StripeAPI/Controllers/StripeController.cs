using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace StripeAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class StripeController : ControllerBase
  {
    private readonly BalanceService _balanceService;

    public StripeController(BalanceService balanceService)
    {
      _balanceService = balanceService;
    }

    [HttpGet("balance")]
    public IActionResult GetBalance()
    {
      var balance = _balanceService.Get();
      return Ok(balance);
    }
  }
}
