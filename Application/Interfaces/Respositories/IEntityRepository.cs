using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Respositories
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetAllWithPagination(Expression<Func<T, bool>> filter = null, int PageSize = 0, int PageIndex = 0);
        T Get(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
