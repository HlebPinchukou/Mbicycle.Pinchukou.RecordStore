using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RecordStoreContext _context;

        public AlbumRepository(RecordStoreContext context)
        {
            _context = context;
        }

        public Album Add(Album item)
        {
            var result = _context.Albums.Add(item);
            _context.SaveChanges();

            return result.Entity;
        }

        public void Delete(Album item)
        {
            _context.Artists.Remove(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = new Album { Id = id };
            _context.Artists.Attach(item);
            Delete(item);
        }

        public ICollection<Album> Get()
        {
            return _context.Albums.ToList();
        }

        public Album Get(int id)
        {
            var result = _context.Artists
                .Where(x => x.Id == id)
                .FirstOrDefault();

            result ??= new Album();

            return result;
        }
        public void Update(Album item)
        {
            _context.Update(item);
            _context.SaveChanges();

        }
    }

}
