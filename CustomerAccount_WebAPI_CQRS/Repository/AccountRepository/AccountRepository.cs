using CustomerAccount_WebAPI_CQRS.Data;
using CustomerAccount_WebAPI_CQRS.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerAccount_WebAPI_CQRS.Repository.AccountRepository
{
    public class AccountRepository : IAccountRepository

    {
        public readonly AppDBContext _dbContext;

        public AccountRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Account> CreateAccountAsync(Account account)
        {
            var result = _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAccountAsync(int id)
        {
            var rem = _dbContext.Accounts.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Accounts.Remove(rem);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            var rem = await _dbContext.Accounts.ToListAsync();
            return rem;
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            var rem = await _dbContext.Accounts.Where(x => x.Id == id).FirstOrDefaultAsync();
            return rem;
        }

        public async Task<int> UpdateAccountAsync(Account account)
        {
            _dbContext.Accounts.Update(account);
            return await _dbContext.SaveChangesAsync();
        }

        
    }
}
