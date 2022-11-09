using Microsoft.EntityFrameworkCore;
using RecordStore.DataAccess.Context;
using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public class InStockRepository : Repository<InStock>, IInStockRepository
    {
        private readonly RecordStoreContext _context;

        public InStockRepository(RecordStoreContext context) : base(context)
        {
            _context = context;
        }

        protected override InStock CreateEntity(int id)
        {
            return new InStock {Id = id};
        }

        public override async Task<ICollection<InStock>> GetAsync()
        {
            var query = _context.InStocks
                .Select(x => new InStock
                {
                    Id = x.Id,
                    Album = x.Album,
                    TypeOfRecord = x.TypeOfRecord,
                    Price = x.Price,
                    AlbumId = x.AlbumId,
                });

            var result = await query.ToListAsync();

            return result;
        }

        public ICollection<InStock> GetBy()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<InStock>> GetAllInStockDashboardAsync()
        {
            var query = _context.InStocks
                .Select(x => new InStock
                {
                    Id = x.Id,
                    Album = new Album
                    {
                        Name = x.Album.Name,
                    },
                    AlbumId = x.AlbumId,
                    Price = x.Price,
                    TypeOfRecord = x.TypeOfRecord,
                });

            var result = await query.ToListAsync();

            return result;
        }

        public async Task<int> AddAsync(
            int albumId,
            string typeOfRecord,
            decimal price)
        {
            var inStock = new InStock
            {
                Album = new Album {Id = albumId},
                TypeOfRecord = typeOfRecord,
                Price = price,

            };

            _context.Attach(inStock.Album);
            var result = await AddAsync(inStock);
            _context.Entry(inStock.Album).State = EntityState.Detached;

            return result.Id;
        }

        public Task<ICollection<InStock>> GetAllInStocksDashboardAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(int albumId, string typeOfRecord, string album, decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int commandAlbumId, string commandTypeOfRecord, string commandAlbum, decimal commandPrice)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(
            int inStockId, 
            int albumId,
            string typeOfRecord, 
            decimal price)
        {
            var sale = new InStock()
            {
                Id = inStockId,
                Album = new Album {Id = albumId},
                Price = price,
                TypeOfRecord = typeOfRecord,
            };
       
            _context.ChangeTracker.Clear();
            _context.Attach(sale);
            await UpdateAsync(sale);
            _context.ChangeTracker.Clear();
        
            return inStockId;
        }
    }
}