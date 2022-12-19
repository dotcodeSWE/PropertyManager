using Customer.Core.Repository.Entities;
using Customer.Core.Repository.Interfaces;
using DotCode.CqrsUtils.BaseClasses;
using MapsterMapper;

namespace Customer.Core.Features.Commands.Customer.Update
{
    public class UpdateCustomerCommandHandler : BaseCommandHandler<UpdateCustomerCommand, Domain.Customer>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public override async Task<Domain.Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity != null)
            {
                _mapper.Map(request, entity);

                entity = await _repo.UpdateAsync(entity);
                var customer = _mapper.Map<CustomerEntity, Domain.Customer>(entity);

                return customer;
            }
            return null;
        }

    }
}