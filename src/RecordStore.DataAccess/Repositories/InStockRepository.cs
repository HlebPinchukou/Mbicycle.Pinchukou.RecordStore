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
            return new InStock { Id = id };
        }

        public override ICollection<InStock> Get()
        {
            return _context.InStocks
                .Include(x => x.Album)
                .ToList();
        }

        public ICollection<InStock> GetBy()
        {
            throw new NotImplementedException();
        }
    }
}