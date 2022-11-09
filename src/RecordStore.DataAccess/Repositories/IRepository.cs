﻿using RecordStore.DataAccess.Model.Base;

namespace RecordStore.DataAccess.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> AddAsync(T item);

        Task DeleteAsync (T item);

        Task DeleteAsync(int id);

        Task UpdateAsync(T item);

        Task<ICollection<T>> GetAsync();

        Task<T> GetAsync(int id);
    }
}