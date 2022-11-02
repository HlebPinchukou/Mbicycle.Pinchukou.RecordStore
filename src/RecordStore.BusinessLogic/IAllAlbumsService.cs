using System.Collections.Generic;
using RecordStore.BusinessLogic.Dto;


namespace RecordStore.BusinessLogic;

public interface IAlbumsService
{
    IEnumerable<AlbumDto> GetAllInStocks();
}