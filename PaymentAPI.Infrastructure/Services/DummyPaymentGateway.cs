public class DummyPaymentGateway : IPaymentGateway
{
    public async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request)
    {
        // Simulate processing delay
        await Task.Delay(1000);

        // Simulate success/failure (80% success rate)
        bool isSuccess = new Random().NextDouble() < 0.8;

        return new PaymentResult
        {
            IsSuccess = isSuccess,
            TransactionId = isSuccess ? Guid.NewGuid().ToString() : null,
            ErrorMessage = isSuccess ? null : "Payment failed"
        };
    }

    public async Task<AccountStatus> GetAccountStatusAsync(int accountId)
    {
        // Simulate processing delay
        await Task.Delay(500);

        return new AccountStatus
        {
            AccountId = accountId,
            Balance = new Random().Next(1000, 10000),
            IsActive = true
        };
    }
}