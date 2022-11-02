using RecordStore.BusinessLogic.Dto;
using RecordStore.DataAccess.Repositories;

namespace RecordStore.BusinessLogic;

public class AlbumsService : IAlbumsService
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumsService(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository));
    }

    public IEnumerable<AlbumDto> GetAllSales()
    {
        var result = _albumRepository.Get().Select(album =>
            new AlbumDto
            {
                Id = album.Id,
                Genre = album.Genre,
                Name = album.Name,
                Cover = album.Cover,
                Artist = album.Artist.Name,
                ArtistId = album.Artist.Id,
                YearOfRelease = album.YearOfRelease,
            });

        return result;
    }

    public IEnumerable<AlbumDto> GetAllInStocks()
    {
        throw new System.NotImplementedException();
    }
}
