using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class CreateProductViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
