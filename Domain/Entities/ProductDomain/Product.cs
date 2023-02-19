using Domain.Common;
using Domain.Entities.CategoryDomain;
using Domain.Entities.OrderDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductDomain
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public ICollection<Order> Orders{ get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }  
    }
}
