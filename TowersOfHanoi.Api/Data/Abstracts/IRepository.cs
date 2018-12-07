using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TowersOfHanoi.Api.Data.Entities;

namespace TowersOfHanoi.Api.Data.Abstracts
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(long? id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<int> UpdateAsync();
        Task<int> DeleteAsync(TEntity entity);
        IQueryable<TEntity> Query { get; }
    }
}
