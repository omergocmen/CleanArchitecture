using Domain.Common;
using Domain.Entities.CustomerDomain;
using Domain.Entities.ProductDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderDomain
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
