using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderDomain
{
    public class OrderProductViewModel
    {
        public Guid Guid { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public bool IsActive { get; set; }
    }
}
