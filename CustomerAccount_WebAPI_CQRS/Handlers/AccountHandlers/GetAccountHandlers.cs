using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Query;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Handlers.CustomerHandlers
{
    public class GetAccountHandlers : IRequestHandler<GetAccountByIdQuery, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountHandlers(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAccountByIdAsync(request.Id);
        }
    }
}
