using DotCode.CqrsUtils.Interfaces.Commands;
using MediatR;

namespace Customer.Core.Features.Commands.Customer.Create
{
    public class CreateCustomerCommand : ICommand<Domain.Customer>
    {
        public string Name { get; set; }
        public string AreaId { get; set; }
        public string TeamId { get; set; }
    }
}