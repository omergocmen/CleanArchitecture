using Domain.Entities.CategoryDomain;
using Domain.Entities.CustomerDomain;
using Domain.Entities.OrderDomain;
using Domain.Entities.ProductDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
