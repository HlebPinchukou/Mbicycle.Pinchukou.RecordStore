using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public interface IAlbumRepository
    {
        Album Add (Album item);
        void Delete (Album item);
        void Delete(int id);
        void Update (Album item);
        ICollection<Album> Get();
        Album Get(int id);
    }
}
