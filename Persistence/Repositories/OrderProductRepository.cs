using Application.Interfaces.Respositories;
using Domain.Entities.OrderDomain;
using Domain.Entities.ProductDomain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OrderProductRepository : EfEntityRepositoryBase<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(ApplicationContext context) : base(context){}
    }
}
