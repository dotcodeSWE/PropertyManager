using DotCode.RepositoryUtils.Interfaces;
using Customer.Core.Repository.Entities;

namespace Customer.Infrastructure.EFCore.Repository.Interface
{
    public interface ICustomerSourceRepository : IAsyncRepository<CustomerEntity>
    {
    }
}
