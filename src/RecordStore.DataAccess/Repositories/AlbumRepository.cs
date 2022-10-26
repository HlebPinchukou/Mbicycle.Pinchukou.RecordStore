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
            _context = context;
        }
        
        protected override Album CreateEntity(int id)
        {
            return new Album { Id = id };
        }
        
        public override ICollection<Album> Get()
        {
            return _context.Albums
                .Include(x => x.Name)
                .ToList();
        }
    }
}