using Customer.Core.Repository.Entities;
using DotCode.RepositoryUtils.Interfaces;

namespace Customer.Core.Repository.Interfaces
{
    public interface ICustomerRepository : IAsyncRepository<CustomerEntity>
    {
    }
}
