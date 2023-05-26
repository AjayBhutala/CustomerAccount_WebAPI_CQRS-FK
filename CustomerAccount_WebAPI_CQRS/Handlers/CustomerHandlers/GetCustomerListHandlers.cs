using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Query;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Handlers.CustomerHandlers
{
    public class GetCustomerListHandlers : IRequestHandler<GetCustomerListQuery, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerListHandlers(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAllCustomersAsync();
        }
    }
}
