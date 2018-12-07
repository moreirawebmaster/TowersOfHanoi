using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TowersOfHanoi.CrossCutting;
using TowersOfHanoi.Domain.Common;

namespace TowersOfHanoi.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : AbstractEntity
    {
        private readonly IDatabaseService _databaseService;

        public IQueryable<TEntity> Query => _databaseService.Set<TEntity>();

        public Repository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public Task<TEntity> GetByIdAsync(object id, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                var entity = _databaseService.Set<TEntity>();
                if (includes != null && includes.Any())
                    entity = includes.Aggregate(entity,
                        (current, include) => current.Include(include) as IDbSet<TEntity>);


                var data = entity.Find(id);
                return Task.FromResult(data);
            }
            catch (DbEntityValidationException e)
            {
                throw CustomException(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> by = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Query;

            if (includes != null && includes.Any())
                query = includes.Aggregate(query, (current, include) => current.Include(include));


            if (by != null)
                query = query.Where(by);

            var data = await query.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<TEntity> GetByOneAsync(Expression<Func<TEntity, bool>> by,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Query;

            if (includes != null && includes.Any())
                query = includes.Aggregate(query, (current, include) => current.Include(include));


            var data = await query.AsNoTracking().FirstOrDefaultAsync(by);
            return data;
        }


        public TEntity Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _databaseService.Set<TEntity>().Add(entity);
                return entity;
            }
            catch (DbEntityValidationException e)
            {
                throw CustomException(e);
            }
        }

        public void BulkInsert(List<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                foreach (var entity in entities)
                    _databaseService.Set<TEntity>().Add(entity);
            }
            catch (DbEntityValidationException e)
            {
                throw CustomException(e);
            }
        }

        public void BulkUpdate(List<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                foreach (var entity in entities)
                    _databaseService.Entry(entity);
            }
            catch (DbEntityValidationException e)
            {
                throw CustomException(e);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _databaseService.Entry(entity);
            }
            catch (DbEntityValidationException e)
            {
                throw CustomException(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _databaseService.Set<TEntity>().Remove(entity);
            }
            catch (DbEntityValidationException e)
            {
                throw CustomException(e);
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _databaseService.SaveChangesAsync() > 0;
        }

        private Exception CustomException(DbEntityValidationException ex)
        {
            var msg = ex.EntityValidationErrors.Aggregate(string.Empty,
                (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1,
                        (current, validationError) =>
                            current +
                            $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}{Environment.NewLine}"));

            return new Exception(msg, ex);
        }
    }
}