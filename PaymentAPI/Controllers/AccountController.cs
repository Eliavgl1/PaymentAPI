// YourProject.API/Controllers/AccountController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("payment")]
    public async Task<ActionResult<PaymentResult>> ProcessPayment([FromBody] PaymentRequest request)
    {
        var result = await _accountService.ProcessPaymentAsync(request);
        return Ok(result);
    }

    [HttpGet("{accountId}/status")]
    public async Task<ActionResult<AccountStatus>> GetAccountStatus(int accountId)
    {
        var status = await _accountService.GetAccountStatusAsync(accountId);
        return Ok(status);
    }
}