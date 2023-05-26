using CustomerAccount_WebAPI_CQRS.Command;
using CustomerAccount_WebAPI_CQRS.Command.CustomerCommand;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CustomerAccount_WebAPI_CQRS.Handlers.AccountHandlers
{
    public class UpdateAccounthandler : IRequestHandler<UpdateAccountCommand, int>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccounthandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<int> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountByIdAsync(request.Id);

            if (account == null) return default;


            account.AccountNumber = request.AccountNumber;
            account.Balance = request.Balance;
            account.CustomerId = request.CustomerId;

            return await _accountRepository.UpdateAccountAsync(account);
        }
    }
}
