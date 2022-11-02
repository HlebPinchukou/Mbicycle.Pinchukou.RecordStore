using RecordStore.BusinessLogic.Dto;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic;

public class InStocksService : IInStocksService
{
    private readonly IInStockRepository _inStockRepository;

    public InStocksService(IInStockRepository inStockRepository)
    {
        _inStockRepository = inStockRepository ?? throw new ArgumentNullException(nameof(inStockRepository));
    }

    public IEnumerable<InStockDto> GetAllSales()
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

        return result;
    }

    public IEnumerable<InStockDto> GetAllInStocks()
    {
        throw new System.NotImplementedException();
    }
}