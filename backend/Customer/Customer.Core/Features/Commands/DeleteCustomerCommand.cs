using DotCode.CqrsUtils.Interfaces.Commands;
using MediatR;

namespace Customer.Core.Features.Commands
{
    public class DeleteCustomerCommand : ICommand<bool>
    {
        public Guid Id { get; set; }
    }
}