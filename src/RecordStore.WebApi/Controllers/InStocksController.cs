using Microsoft.AspNetCore.Mvc;
using RecordStore.BusinessLogic;
using RecordStore.BusinessLogic.Dto;

namespace RecordStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/instock")]
    public class InStocksController : ControllerBase
    {
        private readonly IInStocksService _inStocksService;

        public InStocksController(IInStocksService inStocksService)
        {
            _inStocksService = inStocksService ?? throw new ArgumentNullException(nameof(inStocksService));
        }

        [HttpGet("all")]
        public IEnumerable<InStockDto> Get()
        {
            return _inStocksService.GetAllInStocks();
        }
    }
}