using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductDomain
{
    public class ProductViewModel
    {
        public Guid Guid { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public Guid CategoryId {get; set;}
    }
}
