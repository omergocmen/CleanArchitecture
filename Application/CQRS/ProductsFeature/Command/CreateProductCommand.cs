using Application.Interfaces.Respositories;
using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductFeature.Command
{
    public class CreateProductCommand : IRequest<CreateProductViewModel>
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductViewModel>
        {
            private readonly IProductRepository _repository;
            public CreateProductCommandHandler(IProductRepository repository)
            {
                _repository = repository;
            }

            public async Task<CreateProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = new Product();
                product.ProductName = request.ProductName;
                product.Price = request.Price;
                product.Stock = request.Stock;


                var result = await _repository.AddAsync(product);
                CreateProductViewModel model = new CreateProductViewModel();
                model.ProductId=result.Guid;
                model.ProductName = result.ProductName;
                return model;

            }
        }
    }
}
