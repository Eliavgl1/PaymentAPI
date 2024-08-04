using System.Security.Principal;

public class AccountRepository : IAccountRepository
{
    public async Task<Account> GetAccountAsync(int accountId)
    {
        // TODO: Implement actual database retrieval
        return new Account { Id = accountId, UserName = "DummyUser", Balance = 1000, IsActive = true };
    }

    public async Task UpdateAccountAsync(Account account)
    {
        // TODO: Implement actual database update
        Console.WriteLine($"Account {account.Id} updated");
    }
}
