using CustomerAccount_WebAPI_CQRS.Model;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Command.CustomerCommand
{
    public class UpdateAccountCommand : IRequest<int>
    {
      

        public UpdateAccountCommand(int id, string accountNumber, decimal balance, int customerId)
        {
            Id = id;
            AccountNumber = accountNumber;
            Balance = balance;
            CustomerId = customerId;
        }

        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
