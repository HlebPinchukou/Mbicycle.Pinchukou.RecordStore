using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(RecordStoreContext context) : base(context)
        {
        }

        protected override Album CreateEntity(int id)
        {
            return new Album { Id = id };
        }
    }
}