using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Command.CustomerCommand
{
    public class DeleteCustomerCOmmand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
