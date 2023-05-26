using System.ComponentModel.DataAnnotations;

namespace CustomerAccount_WebAPI_CQRS.Model
{
    public class AccountDTO

    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }

    }
}
