using Application.Interfaces.Respositories;
using Domain.Entities.CustomerDomain;
using Domain.Entities.ProductDomain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CustomerRepository : EfEntityRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context){}
    }
}
