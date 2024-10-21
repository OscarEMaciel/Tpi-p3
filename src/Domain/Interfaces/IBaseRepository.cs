using System;
namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        List<T> GetAll();
        T? GetById<TId>(TId id);
        void Delete(T entity);
        T Update(T entity);
    }
}
