using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<bool> ExistById(int id);

    }
}
