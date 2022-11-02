using RecordStore.BusinessLogic.Dto;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic;

public class ArtistsService : IArtistsService
{
    private readonly IArtistRepository _artistRepository;

    public ArtistsService(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
    }

    public IEnumerable<ArtistDto> GetAllSales()
    {
        var result = _artistRepository.Get().Select(artist =>
            new ArtistDto
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
                Photo = artist.Photo,
            });

        return result;
    }

    public IEnumerable<ArtistDto> GetAllInStocks()
    {
        throw new System.NotImplementedException();
    }
}