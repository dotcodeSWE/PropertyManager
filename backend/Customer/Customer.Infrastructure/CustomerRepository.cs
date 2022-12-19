using Customer.Core.Repository.Entities;
using DotCode.RepositoryUtils.Repositories;
using Customer.Core.Repository.Interfaces;
using Customer.Infrastructure.EFCore.Context;

namespace Customer.Infrastructure
{
    internal class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext context) : base(context)
        {
        }
    }
}
