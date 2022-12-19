using DotCode.CqrsUtils.BaseClasses;
using MapsterMapper;
using MediatR;
using Customer.Core.Repository.Entities;
using Customer.Core.Repository.Interfaces;

namespace Customer.Core.Features.Queries.Customer
{
    public class GetCustomerQueryHandler : BaseQueryHandler<GetCustomerQuery, Domain.Customer>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;


        public GetCustomerQueryHandler(IMapper mapper, ICustomerRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public override async Task<Domain.Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            return _mapper.Map<CustomerEntity, Domain.Customer>(entity);
        }
    }
}