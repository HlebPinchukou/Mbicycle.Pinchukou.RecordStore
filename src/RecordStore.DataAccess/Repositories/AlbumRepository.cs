using Microsoft.EntityFrameworkCore;
using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly RecordStoreContext _context;

        public AlbumRepository(RecordStoreContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override Album CreateEntity(int id)
        {
            return new Album { Id = id };
        }

        public async Task<bool> ExistById(int id)
        {
            var result = await _context.Albums.CountAsync(x => x.Id == id);
            return result == 1;
        }
    }
}