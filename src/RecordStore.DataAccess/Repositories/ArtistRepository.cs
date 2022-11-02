using Microsoft.EntityFrameworkCore;
using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly RecordStoreContext _context;
        
        public ArtistRepository(RecordStoreContext context) : base(context)
        {
            _context = context;
        }

        protected override Artist CreateEntity(int id)
        {
            return new Artist { Id = id };
        }
        
        public override ICollection<Artist> Get()
        {
            return _context.Artists
                .Include(x => x.Name)
                .ToList();
        }
    }
}