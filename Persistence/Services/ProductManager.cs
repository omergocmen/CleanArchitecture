using Application.Interfaces.Respositories;
using Application.Interfaces.Services;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        /*public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }*/
    }
}
