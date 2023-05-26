using CustomerAccount_WebAPI_CQRS.Command;
using CustomerAccount_WebAPI_CQRS.Command.CustomerCommand;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Handlers.CustomerHandlers
{
    public class DeleteAccountHandler : IRequestHandler<DeleteCustomerCOmmand, int>
    {

        private readonly ICustomerRepository _customerRepository;

        public DeleteAccountHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<int> Handle(DeleteCustomerCOmmand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
            if (customer == null) return default;
            return await _customerRepository.DeleteCustomerAsync(request.Id);
        }
    }
}
