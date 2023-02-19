using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.ProductDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Command
{
    public class UpdateProductCommand : IRequest<ProductViewModel>
    {
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductViewModel>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ProductViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product updatedProduct = _mapper.Map<Product>(request);
                await _productRepository.UpdateAsync(updatedProduct);
                return _mapper.Map<ProductViewModel>(updatedProduct);
            }
        }
    }
}
