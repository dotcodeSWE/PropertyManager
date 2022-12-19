using DotCode.RepositoryUtils.Repositories;
using Customer.Core.Repository.Entities;
using Customer.Infrastructure.EFCore.Context;
using Customer.Infrastructure.EFCore.Repository.Interface;

namespace Customer.Infrastructure.EFCore.Repository
{
    public class CustomerSourceRepository : BaseRepository<CustomerEntity>, ICustomerSourceRepository
    {
        public CustomerSourceRepository(CustomerContext context) : base(context)
        {
        }
    }
}
