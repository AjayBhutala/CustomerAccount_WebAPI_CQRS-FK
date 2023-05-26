using CustomerAccount_WebAPI_CQRS.Model;

namespace CustomerAccount_WebAPI_CQRS.Repository
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);

        public Task<Customer> CreateCustomerAsync(Customer customer);
        public Task<int> UpdateCustomerAsync(Customer customer);
        public Task<int> DeleteCustomerAsync(int id);
    }
}
