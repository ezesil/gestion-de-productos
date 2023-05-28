using GestionDeProductos.DataAccess.Interfaces;
using System.Collections.Generic;

public interface IRepository<T>
{
    T SelectOne(object whereParams = null);
    T SelectOne(T obj);
    IEnumerable<T> SelectAll(object whereParams = null);
    int Insert(T entity);
    int Update(T entity, object whereParams = null);
    int Delete(object whereParams);
    void Open();
    void Commit();
    void Rollback();
    void PreloadCache();
}