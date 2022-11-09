using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<bool> ExistById(int id);

    }
}
