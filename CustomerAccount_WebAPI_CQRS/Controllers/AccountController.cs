using AutoMapper;
using CustomerAccount_WebAPI_CQRS.Command;
using CustomerAccount_WebAPI_CQRS.Command.AccountCommand;
using CustomerAccount_WebAPI_CQRS.Command.CustomerCommand;
using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAccount_WebAPI_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<AccountDTO>> AccountList()
        {
            var accounts = await _mediator.Send(new GetAccountListQuery());
            var accountDtos = _mapper.Map<List<AccountDTO>>(accounts);
            return accountDtos;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<AccountDTO> AccountById(int id)
        {
            var account = await _mediator.Send(new GetAccountByIdQuery() { Id = id });
            var accountDto = _mapper.Map<AccountDTO>(account);
            return accountDto;
        }

        // POST api/<CustomerController>
        [HttpPost]
        /*public async  Task<Account> CreateAccount(Account account) 
        {
            var accountReturn = await _mediator.Send(new CreateAccountCommand(
                account.AccountNumber,
                account.Balance, 
                account.CustomerId));

            return accountReturn;
        }*/
        public async Task<AccountDTO> CreateAccount(AccountDTO accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);

            var createdAccount = await _mediator.Send(new CreateAccountCommand(
                account.AccountNumber,
                account.Balance,
                account.CustomerId));

            var createdAccountDto = _mapper.Map<AccountDTO>(createdAccount);

            return createdAccountDto;
        }
            // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<int> UpdateAccount(AccountDTO accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            var accountReturn = await _mediator.Send(new UpdateAccountCommand(
                account.Id,
                account.AccountNumber,
                account.Balance,
                account.CustomerId));
            return accountReturn;
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> DeleteAccount(int id)
        {
            int Id = await _mediator.Send(new DeleteAccountCommand() { Id = id });

            if (Id > 0)
            {
                return Ok(); 
            }
            else if (Id == 0)
            {
                return NotFound(); 
            }
            else
            {
                return StatusCode(500, "An error occurred while deleting the customer."); 
            }
        }
    }
}
