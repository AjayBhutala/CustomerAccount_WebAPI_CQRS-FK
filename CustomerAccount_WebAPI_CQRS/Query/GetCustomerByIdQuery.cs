using CustomerAccount_WebAPI_CQRS.Model;
using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Query
{
    public class GetCustomerByIdQuery: IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
