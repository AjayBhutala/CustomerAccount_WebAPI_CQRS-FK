using CustomerAccount_WebAPI_CQRS.Command;
using CustomerAccount_WebAPI_CQRS.Command.AccountCommand;
using CustomerAccount_WebAPI_CQRS.Command.CustomerCommand;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Handlers.AccountHandlers
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, int>
    {

        private readonly IAccountRepository _accountRepository;

        public DeleteAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<int> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountByIdAsync(request.Id);
            if (account == null) return default;
            return await _accountRepository.DeleteAccountAsync(request.Id);
        }
    }
}
