using Domain;
using Domain.Features.Queries.Chores;
using Domain.Features.Queries.Customers;
using Domain.Features.Queries.Periodics;
using Domain.Repository.Interfaces;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.Features.Queries.CustomerChores;

public class GetCustomerChoresByCustomerIdQueryHandler : IRequestHandler<GetCustomerChoresByCustomerIdQuery, IList<Domain.CustomerChore>>
{
    private readonly ICustomerChoreRepository _repo;
    private readonly IMapper _mapper;
    private ILogger<GetCustomerChoresByCustomerIdQueryHandler> _logger;
    private IMediator _mediator;
    public GetCustomerChoresByCustomerIdQueryHandler(ICustomerChoreRepository repo, IMapper mapper, ILogger<GetCustomerChoresByCustomerIdQueryHandler> logger, IMediator mediator)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
        _mediator = mediator;
    }
    public async Task<IList<Domain.CustomerChore>> Handle(GetCustomerChoresByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var customerChores = _mapper.Map<IList<Domain.CustomerChore>>(await _repo.GetQuery(x => x.CustomerId == request.Id));
        var chores = await _mediator.Send(new GetAllChoresQuery());
        var customers = await _mediator.Send(new GetAllCustomersQuery());
        var periodic = await _mediator.Send(new GetAllPeriodicsQuery());

        foreach (var customerChore in customerChores)
        {
            customerChore.Chore = chores.FirstOrDefault(x => x.Id.ToString() == customerChore.ChoreId); 
            customerChore.Customer = customers.FirstOrDefault(x => x.Id.ToString() == customerChore.CustomerId);
            customerChore.Periodic = periodic.FirstOrDefault(x => x.Id.ToString() == customerChore.PeriodicId);
        }

        return customerChores;
    }
}