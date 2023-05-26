using CustomerAccount_WebAPI_CQRS.Command;
using CustomerAccount_WebAPI_CQRS.Command.AccountCommand;
using CustomerAccount_WebAPI_CQRS.Command.CustomerCommand;
using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Handlers.AccountHandlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new Account
            {
                 
                AccountNumber = request.AccountNumber,
                Balance = request.Balance,
                CustomerId = request.CustomerId
            };
            return await _accountRepository.CreateAccountAsync(account);
        }
    }
}
