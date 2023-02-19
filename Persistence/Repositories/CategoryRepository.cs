using Application.Interfaces.Respositories;
using Domain.Entities.CategoryDomain;
using Domain.Entities.ProductDomain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context){}
    }
}
