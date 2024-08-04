// YourProject.Application/Services/AccountService.cs
public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPaymentGateway _paymentGateway;

    public AccountService(IAccountRepository accountRepository, IPaymentGateway paymentGateway)
    {
        _accountRepository = accountRepository;
        _paymentGateway = paymentGateway;
    }

    public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
    {
        var account = await _accountRepository.GetAccountAsync(request.AccountId);
        if (account == null || !account.IsActive)
        {
            return new PaymentResult { IsSuccess = false, ErrorMessage = "Invalid account" };
        }

        var result = await _paymentGateway.ProcessPaymentAsync(request);
        if (result.IsSuccess)
        {
            account.Balance -= request.Amount;
            await _accountRepository.UpdateAccountAsync(account);
        }

        return result;
    }

    public async Task<AccountStatus> GetAccountStatusAsync(int accountId)
    {
        return await _paymentGateway.GetAccountStatusAsync(accountId);
    }
}