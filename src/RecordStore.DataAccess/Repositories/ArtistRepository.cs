using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(RecordStoreContext context) : base(context)
        {
        }

        protected override Artist CreateEntity(int id)
        {
            return new Artist { Id = id };
        }
    }
}