using Azure;
using CustomerAccount_WebAPI_CQRS.Command;
using CustomerAccount_WebAPI_CQRS.Command.CustomerCommand;
using CustomerAccount_WebAPI_CQRS.Model;
using CustomerAccount_WebAPI_CQRS.Query;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerAccount_WebAPI_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<Customer>> CustomerList()
        {
            var customer = await _mediator.Send(new GetCustomerListQuery());
            return customer;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<Customer> CustomerById(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery() {Id = id});
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async  Task<Customer> CreateCustomer(Customer customer) 
        {
            var customerReturn = await _mediator.Send(new CreateCustomerCommand(
                customer.Name,
                customer.Email, 
                customer.Phone));
            return customerReturn;
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<int> UpdateCustomer(Customer customer)
        {
            var customerReturn = await _mediator.Send(new UpdateCustomerCommand(
                customer.Id,
                customer.Name,
                customer.Email,
                customer.Phone));
            return customerReturn;
        }



        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            int Id = await _mediator.Send(new DeleteCustomerCOmmand() { Id = id });

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
