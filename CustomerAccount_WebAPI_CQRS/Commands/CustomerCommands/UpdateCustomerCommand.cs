using CustomerAccount_WebAPI_CQRS.Model;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Command.CustomerCommand
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public UpdateCustomerCommand(int id, string name, string email, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
