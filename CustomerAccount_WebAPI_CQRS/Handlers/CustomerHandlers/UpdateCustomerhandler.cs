using CustomerAccount_WebAPI_CQRS.Command;
using CustomerAccount_WebAPI_CQRS.Command.CustomerCommand;
using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CustomerAccount_WebAPI_CQRS.Handlers.CustomerHandlers
{
    public class UpdateCustomerhandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerhandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);

            if (customer == null) return default;


            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.Phone = request.Phone;

            return await _customerRepository.UpdateCustomerAsync(customer);
        }


    }
}
