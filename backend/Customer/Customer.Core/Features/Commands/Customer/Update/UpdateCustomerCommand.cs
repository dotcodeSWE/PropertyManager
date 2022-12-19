using DotCode.CqrsUtils.Interfaces.Commands;
using MediatR;

namespace Customer.Core.Features.Commands.Customer.Update
{
    public class UpdateCustomerCommand : ICommand<Domain.Customer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AreaId { get; set; }
        public string TeamId { get; set; }
    }
}