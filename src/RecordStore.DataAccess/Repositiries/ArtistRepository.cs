using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public interface IArtistRepository
    {
        public interface IProductRepository
        Artist Add (Artist item);
        void Delete (Artist item);
        void Delete(int id);
        void Update (Artist item);
        ICollection<Artist> Get();
        Artist Get(int id);
    }
}
