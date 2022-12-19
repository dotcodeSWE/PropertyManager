using DotCode.CqrsUtils.Interfaces.Commands;
using MediatR;

namespace Customer.Core.Features.Commands.Customer.Create
{
    public class CreateCustomerCommand : ICommand<Domain.Customer>
    {
        public string Name { get; set; }
        public Guid AreaId { get; set; }
        public Guid TeamId { get; set; }
    }
}