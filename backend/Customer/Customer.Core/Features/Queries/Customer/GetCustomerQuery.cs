using DotCode.CqrsUtils.Interfaces.Queries;
using MediatR;

namespace Customer.Core.Features.Queries.Customer
{
    public class GetCustomerQuery : IQuery<Domain.Customer>
    {
        public Guid Id { get; set; }
    }
}