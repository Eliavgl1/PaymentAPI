public interface IPaymentGateway
{
    Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request);
    Task<AccountStatus> GetAccountStatusAsync(int accountId);
}