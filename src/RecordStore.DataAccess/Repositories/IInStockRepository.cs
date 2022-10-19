using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public interface IInStockRepository : IRepository<InStock>
    {
        ICollection<InStock> GetBy();
    }
}