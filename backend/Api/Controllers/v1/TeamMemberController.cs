using Domain.Features.Queries.TeamMembers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain.Domain;
using Api.Dto.Request.TeamMember.v1;
using Domain.Features.Commands.TeamMember;

namespace Api.Controllers.v1;

[ApiController]
[Route("/api/v1/[controller]")]
public class TeamMemberController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TeamMemberController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IList<TeamMember>>> GetAllTeamMembers()
    {
        var result = await _mediator.Send(new GetAllTeamMembersQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<TeamMember>> PostTeamMemberAsync(PostTeamMemberRequestDto request)
    {
        var result = await _mediator.Send(_mapper.Map<PostTeamMemberRequestDto, AddTeamMemberCommand>(request));
        return Ok(result);
    }
}