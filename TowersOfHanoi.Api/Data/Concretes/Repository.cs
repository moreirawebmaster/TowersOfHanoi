using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TowersOfHanoi.Api.Data.Abstracts;
using TowersOfHanoi.Api.Data.Entities;

namespace TowersOfHanoi.Api.Data.Concretes
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMyDbContext _context;

        public IQueryable<TEntity> Query => _context.Set<TEntity>();

        public Repository(IMyDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(long? id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Query;

            if (includes != null)
                foreach (var include in includes)
                    query = _context.Set<TEntity>().Include(include);

            var data = await query.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }
        
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbEntityValidationException e)
            {
                throw CustomException(e);
            }
        }

        public async Task<int> UpdateAsync()
        {
            var data = await _context.SaveChangesAsync();
            return data;
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _context.Set<TEntity>().Remove(entity);
                var data = await _context.SaveChangesAsync();
                return data;
            }
            catch (DbEntityValidationException e)
            {
                throw CustomException(e);
            }
        }

        private Exception CustomException(DbEntityValidationException ex)
        {
            var msg = ex.EntityValidationErrors.Aggregate(string.Empty,
                (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1,
                        (current, validationError) =>
                            current +
                            ($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}" +
                             Environment.NewLine)));

            return new Exception(msg, ex);
        }
    }
}