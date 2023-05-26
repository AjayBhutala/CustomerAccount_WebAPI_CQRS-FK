using CustomerAccount_WebAPI_CQRS.Data;
using CustomerAccount_WebAPI_CQRS.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerAccount_WebAPI_CQRS.Repository.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository

    {
        public readonly AppDBContext _dbContext;

        public CustomerRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var result = _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            var rem = _dbContext.Customers.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Customers.Remove(rem);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var rem = await _dbContext.Customers.ToListAsync();
            return rem;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var rem = await _dbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
            return rem;
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            return await _dbContext.SaveChangesAsync();
        }

    }
}
