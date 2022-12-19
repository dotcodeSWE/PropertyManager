using DotCode.CqrsUtils.Interfaces.Commands;
using MediatR;

namespace Customer.Core.Features.Commands.Customer.Delete
{
    public class DeleteCustomerCommand : ICommand<bool>
    {
        public Guid Id { get; set; }
    }
}