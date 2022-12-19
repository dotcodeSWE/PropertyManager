using DotCode.ApiUtils;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Customer.Api.Dto.Requests.Customer.v1;
using Customer.Api.Dto.Response.Customer.v1;
using Customer.Core.Features.Commands.Customer.Create;
using Customer.Core.Features.Queries.Customer;
using Customer.Core.Features.Commands.Customer.Update;
using Customer.Core.Features.Commands;

namespace Customer.Api.Controllers.Customer.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomerController(ILogger<CustomerController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetCustomer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDto<CustomerResponseDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetCustomer([FromQuery] GetCustomerRequestDto request)
    {
        try
        {
            var result = await _mediator.Send(_mapper.Map<GetCustomerRequestDto, GetCustomerQuery>(request));
            return result != null ? Ok(new BaseResponseDto<CustomerResponseDto>
            {
                Result = _mapper.Map<CustomerResponseDto>(result)
            }) : NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {ControllerName} {ActionName}", nameof(CustomerController), nameof(GetCustomer));
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(Name = "PostCustomer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDto<CustomerResponseDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PostCustomer([FromBody] PostCustomerRequestDto request)
    {
        try
        {
            var result = await _mediator.Send(_mapper.Map<PostCustomerRequestDto, CreateCustomerCommand>(request));
            return result != null ? Ok(new BaseResponseDto<CustomerResponseDto>
            {
                Result = _mapper.Map<CustomerResponseDto>(result)
            }) : NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {ControllerName} {ActionName}", nameof(CustomerController), nameof(PostCustomer));
            return BadRequest(ex.Message);
        }
    }

    [HttpPut(Name = "PutCustomer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDto<CustomerResponseDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PutCustomer([FromBody] PutCustomerRequestDto request)
    {
        try
        {
            var result = await _mediator.Send(_mapper.Map<PutCustomerRequestDto, UpdateCustomerCommand>(request));
            return result != null ? Ok(new BaseResponseDto<CustomerResponseDto>
            {
                Result = _mapper.Map<CustomerResponseDto>(result)
            }) : NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {ControllerName} {ActionName}", nameof(CustomerController), nameof(PutCustomer));
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete(Name = "DeleteCustomer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDto<bool>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteCustomer([FromBody] DeleteCustomerRequestDto request)
    {
        try
        {
            var result = await _mediator.Send(_mapper.Map<DeleteCustomerRequestDto, DeleteCustomerCommand>(request));
            return Ok(new BaseResponseDto<bool>
            {
                Result = result
            }); 

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {ControllerName} {ActionName}", nameof(CustomerController), nameof(DeleteCustomer));
            return BadRequest(ex.Message);
        }
    }
}
