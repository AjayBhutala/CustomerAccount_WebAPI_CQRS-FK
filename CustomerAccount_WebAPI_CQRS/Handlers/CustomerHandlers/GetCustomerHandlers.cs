using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Query;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerHandlers : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandlers(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByIdAsync(request.Id);
        }
    }
}
