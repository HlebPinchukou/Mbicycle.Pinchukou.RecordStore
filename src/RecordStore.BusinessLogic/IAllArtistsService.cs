using System.Collections.Generic;
using RecordStore.BusinessLogic.Dto;


namespace RecordStore.BusinessLogic;

public interface IArtistsService
{
    IEnumerable<ArtistDto> GetAllInStocks();
}