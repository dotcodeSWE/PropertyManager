using DotCode.CqrsUtils.BaseClasses;
using MapsterMapper;
using MediatR;
using Customer.Core.Repository.Entities;
using Customer.Core.Repository.Interfaces;

namespace Customer.Core.Features.Commands.Customer.Create
{
    public class CreateCustomerCommandHandler : BaseCommandHandler<CreateCustomerCommand, Domain.Customer>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        public override async Task<Domain.Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return null;
            }
            var entity = _mapper.Map<CustomerEntity>(request);
            entity = await _repo.AddAsync(entity);
            var customer = _mapper.Map<Domain.Customer>(entity);

            return customer;

        }
    }
}