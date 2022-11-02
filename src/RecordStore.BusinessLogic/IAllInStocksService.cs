using System.Collections.Generic;
using RecordStore.BusinessLogic.Dto;


namespace RecordStore.BusinessLogic;

public interface IInStocksService
{
    IEnumerable<InStockDto> GetAllInStocks();
}