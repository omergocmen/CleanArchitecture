using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderDomain
{
    public class OrderViewModel
    {
        public Guid Guid { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
    }
}
