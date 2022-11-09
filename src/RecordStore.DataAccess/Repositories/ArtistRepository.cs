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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override Artist CreateEntity(int id)
        {
            return new Artist { Id = id };
        }

        public async Task<bool> ExistById(int id)
        {
            var result = await _context.Artists.CountAsync(x => x.Id == id);
            return result == 1;
        }
    }
}