using Application.Interfaces.Respositories;
using Domain.Common;
using Domain.Pagination;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
    {
        protected readonly ApplicationContext _context;
        public EfEntityRepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = _context.Attach(entity);
            var updated = entry.CurrentValues.Clone();
            entry.Reload();
            entry.CurrentValues.SetValues(updated);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            DbSet<TEntity> entities = _context.Set<TEntity>();
            return await entities.SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var item = _context.Set<TEntity>().ToList();

            return filter == null
            ? _context.Set<TEntity>().ToList()
            : _context.Set<TEntity>().Where(filter).ToList();
        }

        public async Task<List<TEntity>> GetAllWithPaginationAsync(PageRequest pageRequest, Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
            ? _context.Set<TEntity>().Skip((pageRequest.Page - 1) * pageRequest.PageSize).Take(pageRequest.PageSize).ToList()
            : _context.Set<TEntity>().Where(filter).Skip((pageRequest.Page- 1) * pageRequest.PageSize).Take(pageRequest.PageSize).ToList();
        }

    }
}
