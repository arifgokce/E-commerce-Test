using Hepsiburada.Common.Interface;
using Hepsiburada.Entities.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hepsiburada.Common.EntityFremwork
{
    public class EfEntityRepositoryBase<TEntity, TContex> : IEntityRepository<TEntity>
            where TEntity : class, IEntity, new()
      where TContex : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContex())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContex())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                return filter == null ?
                    context.Set<TEntity>().Count()
                    : context.Set<TEntity>().Where(filter).Count();
            }
        }

        public List<TEntity> GetAllPageList<Tkey>(Expression<Func<TEntity, Tkey>> orderBy = null, Expression<Func<TEntity, bool>> filter = null, int numberOfObjectsPerPage = 100, int pageNumber = 1)
        {
            using (var context = new TContex())
            {
                return filter == null ?
                    context.Set<TEntity>().OrderBy(orderBy).Skip(numberOfObjectsPerPage * pageNumber).Take(numberOfObjectsPerPage).ToList()
                    : context.Set<TEntity>().Where(filter).OrderBy(orderBy).Skip(numberOfObjectsPerPage * pageNumber).Take(numberOfObjectsPerPage).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContex())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
