using Customer.Core.Repository.Entities;
using Customer.Core.Repository.Interfaces;
using DotCode.CqrsUtils.BaseClasses;
using MapsterMapper;

namespace Customer.Core.Features.Commands.Customer.Delete
{
    public class DeleteCustomerCommandHandler : BaseCommandHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public override async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity != null)
            {
                await _repo.DeleteAsync(entity);

                return true;
            }
            return false;
        }

    }
}