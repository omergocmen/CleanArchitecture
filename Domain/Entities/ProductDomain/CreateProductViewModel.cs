using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductDomain
{
    public class CreateProductViewModel
    {
        public Guid Guid { get; set; }
        public string ProductName { get; set; }
    }
}
