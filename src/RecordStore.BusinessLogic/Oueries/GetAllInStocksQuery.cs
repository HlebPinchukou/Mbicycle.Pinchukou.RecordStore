using MediatR;
using RecordStore.BusinessLogic.Dto;
using RecordStore.DataAccess.Model;
using RecordStore.DataAccess.Repositories;
using RecordStore.BusinessLogic.Wrappers;

namespace RecordStore.BusinessLogic.Oueries
{
    public class GetAllInStocksQuery : IRequest<Result<IEnumerable<InStockDto>>>
    {
    }

    public class GetAllInStocksQueryHandler : IRequestHandler<GetAllInStocksQuery, Result<IEnumerable<InStockDto>>>
    {
        private readonly IInStockRepository _inStockRepository;

        public GetAllInStocksQueryHandler(IInStockRepository inStockRepository)
        {
            _inStockRepository = inStockRepository ?? throw new ArgumentNullException(nameof(inStockRepository));
        }

        Task<Result<IEnumerable<InStockDto>>> IRequestHandler<GetAllInStocksQuery, Result<IEnumerable<InStockDto>>>.Handle(GetAllInStocksQuery request, CancellationToken cancellationToken)
        {
            var result = _inStockRepository.Get().Select(inStock =>
            new InStockDto
            {
                Id = inStock.Id,
                Album = inStock.Album.Name,
                AlbumId = inStock.Album.Id,
                TypeOfRecord = inStock.TypeOfRecord,
                Price = inStock.Price,
            });

            return Task.FromResult(Result.Success(result));
        }
    }
}