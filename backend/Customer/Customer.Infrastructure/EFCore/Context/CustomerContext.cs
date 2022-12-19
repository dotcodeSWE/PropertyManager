using Customer.Core.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.EFCore.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerContext).Assembly);
        }
    }
}
