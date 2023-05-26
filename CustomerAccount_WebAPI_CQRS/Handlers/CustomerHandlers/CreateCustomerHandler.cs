using CustomerAccount_WebAPI_CQRS.Command;
using CustomerAccount_WebAPI_CQRS.Command.CustomerCommand;
using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Handlers.CustomerHandlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone
            };
            return await _customerRepository.CreateCustomerAsync(customer);
        }
    }
}
