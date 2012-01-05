using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace AckBack3.DAL
{
    interface IRepository<TEntity>
     where TEntity : class
    {
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
