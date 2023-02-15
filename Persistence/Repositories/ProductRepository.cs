using Application.Interfaces.Respositories;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductRepository : EfEntityRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context){}
    }
}
