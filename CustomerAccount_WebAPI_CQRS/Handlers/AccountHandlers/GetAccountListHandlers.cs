using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Query;
using CustomerAccount_WebAPI_CQRS.Repository;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Handlers.CustomerHandlers
{
    public class GetAccountListHandlers : IRequestHandler<GetAccountListQuery, List<Account>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountListHandlers(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<Account>> Handle(GetAccountListQuery request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAllAccountsAsync();
        }
    }
}
