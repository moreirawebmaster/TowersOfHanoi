using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TowersOfHanoi.Domain.Common;

namespace TowersOfHanoi.CrossCutting
{
    public interface IRepository<TEntity> where TEntity : AbstractEntity
    {
        Task<TEntity> GetByIdAsync(object id, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> by = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByOneAsync(Expression<Func<TEntity, bool>> by, params Expression<Func<TEntity, object>>[] includes);
        TEntity Insert(TEntity entity);
        void BulkInsert(List<TEntity> entities);
        void BulkUpdate(List<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> SaveAsync();
        IQueryable<TEntity> Query { get; }
        
       
    }
}
