using MediatR;

namespace CustomerAccount_WebAPI_CQRS.Command.AccountCommand
{
    public class DeleteAccountCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
