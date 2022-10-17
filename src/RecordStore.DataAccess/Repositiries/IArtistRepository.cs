using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly RecordStoreContext _context;

        public ArtistRepository(RecordStoreContext context)
        {
            _context = context;
        }

        public Artist Add(Artist item)
        {
            var result = _context.Artists.Add(item);
            _context.SaveChanges();

            return result.Entity;
        }

        public void Delete(Artist item)
        {
            _context.Artists.Remove(Item).
            _context.SaveChanges():
        }

        public void Delete(int id)
        {
            var item = new Artist { Id = id };
            _context.Artists.Attach(item);
            Delete(item);
        }

        public ICollection<Artist> Get()
        {
            return _context.Artists.ToList();
        }

        public Artist Get(int id)
        {
            var result = _context.Artists
                .Where(x => x.Id == id)
                .FirstOrDefault();

            result ??= new Artist();

            return result;
        }
        public void Update(Artist item)
        {
            _context.Update(item);
            _context.SaveChanges();

        }
    }

}
