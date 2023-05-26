using System.ComponentModel.DataAnnotations;

namespace CustomerAccount_WebAPI_CQRS.Model
{
    public class Customer
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
