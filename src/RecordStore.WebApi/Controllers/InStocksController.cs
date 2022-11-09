using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using RecordStore.BusinessLogic.Handlers.Commands.InStock;
using RecordStore.BusinessLogic.Handlers.Queries;
using RecordStore.BusinessLogic.Handlers.Queries.InStock;
using RecordStore.BusinessLogic.Handlers.Commands.InStock;

namespace RecordStore.WebApi.Controllers;

[ApiController]
[Route("api/sale")]
public class InStocksController : ControllerBase
{
    private readonly IMediator _mediator;

    public InStocksController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllInStocksQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("dashboard/all")]
    public async Task<IActionResult> GetForDashboard()
    {
        var query = new GetAllInStocksDashboardQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
        
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddInStockCommand command)
    {
        var result = await _mediator.Send(command);
            
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Created(HttpContext.Request.GetDisplayUrl(), result);
    }
        
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateInStockCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result);
        }
            
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteInStockCommand {InStockId = id};
        var result = await _mediator.Send(command);
        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}