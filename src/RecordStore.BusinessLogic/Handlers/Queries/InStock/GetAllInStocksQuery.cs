using MediatR;
using RecordStore.BusinessLogic.Dto;
using RecordStore.BusinessLogic.Wrappers.Result;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Handlers.Queries
{
    public class GetAllInStocksQuery : IRequestResult<IEnumerable<InStockDto>>
    {
    }

    public class GetAllInStocksQueryHandler : IRequestHandlerResult<GetAllInStocksQuery, IEnumerable<InStockDto>>
    {
        private readonly IInStockRepository _inStockRepository;

        public GetAllInStocksQueryHandler(IInStockRepository inStockRepository)
        {
            _inStockRepository = inStockRepository ?? throw new ArgumentNullException(nameof(inStockRepository));
        }

        async Task<Result<IEnumerable<InStockDto>>> IRequestHandler<GetAllInStocksQuery, Result<IEnumerable<InStockDto>>>.Handle(GetAllInStocksQuery request, CancellationToken cancellationToken)
        {
            var data = (await _inStockRepository.GetAsync())
                .Select(inStock => new InStockDto
                {
                    Id = inStock.Id,
                    TypeOfRecord = inStock.TypeOfRecord,
                    AlbumId = inStock.AlbumId,
                    Album = inStock.Album.Name,
                    Price = inStock.Price,
                });

            return Result.Success(data);
        }
    }
}