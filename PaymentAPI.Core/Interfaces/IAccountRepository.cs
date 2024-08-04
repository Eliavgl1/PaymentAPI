public interface IAccountRepository
{
    Task<Account> GetAccountAsync(int accountId);
    Task UpdateAccountAsync(Account account);
}