using MediatR;
using RecordStore.BusinessLogic.Dto;
using RecordStore.BusinessLogic.Wrappers.Result;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic.Handlers.Queries.InStock
{
    public class GetAllInStocksDashboardQuery : IRequestResult<IEnumerable<InStocksDashboardDto>>
    {
    }

    public class GetAllInStocksForDashboardQueryHandler : IRequestHandlerResult<GetAllInStocksDashboardQuery, IEnumerable<InStocksDashboardDto>>
    {
        private readonly IInStockRepository _inStockRepository;

        public GetAllInStocksForDashboardQueryHandler(IInStockRepository inStockRepository)
        {
            _inStockRepository = inStockRepository ?? throw new ArgumentNullException(nameof(inStockRepository));
        }

        async Task<Result<IEnumerable<InStocksDashboardDto>>> IRequestHandler<GetAllInStocksDashboardQuery, Result<IEnumerable<InStocksDashboardDto>>>.Handle(GetAllInStocksDashboardQuery request, CancellationToken cancellationToken)
        {
            var data = (await _inStockRepository.GetAllInStocksDashboardAsync())
                .Select(inStock => new InStocksDashboardDto
                {
                    Id = inStock.Id,
                    TypeOfRecord = inStock.TypeOfRecord,
                    Album = inStock.Album.Name,
                    AlbumId = inStock.AlbumId,
                    Price = inStock.Price,
                });

            return Result.Success(data);
        }
    }
}