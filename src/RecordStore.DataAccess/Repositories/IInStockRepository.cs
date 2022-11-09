using RecordStore.DataAccess.Model;

namespace RecordStore.DataAccess.Repositories
{
    public interface IInStockRepository : IRepository<InStock>
    {
        Task<ICollection<InStock>> GetAllInStocksDashboardAsync();
        
        Task<bool> ExistById(int id);

        Task<int> AddAsync(
            int albumId, 
            string typeOfRecord, 
            string album, 
            decimal price);

        Task<int> UpdateAsync(int commandAlbumId, string commandTypeOfRecord, string commandAlbum, decimal commandPrice);
    }
}