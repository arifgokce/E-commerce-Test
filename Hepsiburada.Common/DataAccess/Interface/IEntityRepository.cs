using Hepsiburada.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hepsiburada.Common.Interface
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        public List<T> GetList(Expression<Func<T, bool>> Filter = null);
        public T Get(Expression<Func<T, bool>> filter);
        public void Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);
        public List<T> GetAllPageList<Tkey>(Expression<Func<T, Tkey>> orderBy = null, Expression<Func<T, bool>> filter = null, int numberOfObjectsPerPage = 100, int pageNumber = 1);
        public int Count(Expression<Func<T, bool>> filter = null);
    }
}
