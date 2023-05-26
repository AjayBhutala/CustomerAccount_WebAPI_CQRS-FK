using CustomerAccount_WebAPI_CQRS.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerAccount_WebAPI_CQRS.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
          : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
