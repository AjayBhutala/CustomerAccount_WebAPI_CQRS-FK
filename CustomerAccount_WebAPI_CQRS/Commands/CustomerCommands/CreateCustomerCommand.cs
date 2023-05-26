using CustomerAccount_WebAPI_CQRS.Model;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Command.CustomerCommand
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public CreateCustomerCommand(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
