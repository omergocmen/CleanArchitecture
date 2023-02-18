using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
