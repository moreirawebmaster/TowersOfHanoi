using System.Data.Entity;
using System.Threading.Tasks;
using TowersOfHanoi.Domain.Common;

namespace TowersOfHanoi.CrossCutting
{
    public interface IDatabaseService
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : AbstractEntity;
        EntityState Entry<TEntity>(TEntity entity) where TEntity : AbstractEntity;
        Task<int> SaveChangesAsync();
    }
}
