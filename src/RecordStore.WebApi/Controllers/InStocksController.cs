using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecordStore.BusinessLogic.Commands;
using RecordStore.BusinessLogic.Oueries;

namespace Stall.WebApi.Controllers
{
    [ApiController]
    [Route("api/instock")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddInStockCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Error)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}