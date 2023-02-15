using Application.Interfaces.Respositories;
using Domain.Common;
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
        public TEntity Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            var item = _context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Attach(entity);
            var updated = entry.CurrentValues.Clone();
            entry.Reload();
            entry.CurrentValues.SetValues(updated);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            DbSet<TEntity> entities = _context.Set<TEntity>();
            return entities.SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var item = _context.Set<TEntity>().ToList();

            return filter == null
            ? _context.Set<TEntity>().ToList()
            : _context.Set<TEntity>().Where(filter).ToList();
        }

        public List<TEntity> GetAllWithPagination(Expression<Func<TEntity, bool>> filter = null, int PageSize = 10, int PageIndex = 1)
        {
            return filter == null
            ? _context.Set<TEntity>().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList()
            : _context.Set<TEntity>().Where(filter).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }

    }
}
