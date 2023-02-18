using Application.Interfaces.Respositories;
using AutoMapper;
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
            private readonly IMapper _mapper;
            public CreateProductCommandHandler(IProductRepository repository, IMapper mappter)
            {
                _repository = repository;
                _mapper = mappter;
            }

            public async Task<CreateProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = _mapper.Map<Product>(request);
                var result = await _repository.AddAsync(product);
                CreateProductViewModel model= _mapper.Map<CreateProductViewModel>(result);
                return model;
            }
        }
    }
}
