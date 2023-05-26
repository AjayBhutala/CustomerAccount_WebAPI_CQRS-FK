using CustomerAccount_WebAPI_CQRS.Model;

namespace CustomerAccount_WebAPI_CQRS.Repository
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAllAccountsAsync();
        public Task<Account> GetAccountByIdAsync(int id);

        public Task<Account> CreateAccountAsync(Account Account);
        public Task<int> UpdateAccountAsync(Account Account);
        public Task<int> DeleteAccountAsync(int id);
    }
}
