using System.Data.Entity;
using System.Threading.Tasks;
using TowersOfHanoi.Api.Data.Entities;

namespace TowersOfHanoi.Api.Data.Abstracts
{
    public interface IMyDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
