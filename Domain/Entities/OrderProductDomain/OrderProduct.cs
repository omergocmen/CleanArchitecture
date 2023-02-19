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
    public class OrderProduct : BaseEntity
    {
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public Order Order{ get; set; }
    }
}
