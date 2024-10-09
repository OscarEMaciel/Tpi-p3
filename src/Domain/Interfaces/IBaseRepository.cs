using System;

namespace Domain.Interfaces;

public interface IBaseRepository<T> where T :class
{
    private static List<T> _entities = new List<T>();

      public List<T>GetAll();

    public T GetbyId(int id);

    public void Add(T entity);
    public void Update(int id, T entity);

    public void Delete(T entity);
}
 