public interface IAccountService
{
    Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request);
    Task<AccountStatus> GetAccountStatusAsync(int accountId);
}