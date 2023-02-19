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
    public class OrderRepository : EfEntityRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context){}
    }
}
