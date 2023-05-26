using CustomerAccount_WebAPI_CQRS.Model;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Command.AccountCommand
{
    public class CreateAccountCommand : IRequest<Account>
    {
        public CreateAccountCommand(string accountNumber, decimal balance, int customerId)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            CustomerId = customerId;
        }

        public CreateAccountCommand(int id, string accountNumber, decimal balance, int customerId)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            CustomerId = customerId;
        }

        

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
