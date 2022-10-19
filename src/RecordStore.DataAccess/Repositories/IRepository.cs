using RecordStore.DataAccess.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecordStore.DataAccess.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T Add(T item);

        void Delete (T item);

        void Delete(int id);

        void Update(T item);

        ICollection<T> Get();

        T Get(int id);
    }
}