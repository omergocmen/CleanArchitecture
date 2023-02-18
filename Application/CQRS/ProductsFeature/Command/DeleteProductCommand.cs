using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Command
{
    public class DeleteProductCommand : IRequest<ProductViewModel>
    {
        public Guid Guid { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductViewModel>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<ProductViewModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                Product product = await _productRepository.GetAsync(p => p.Guid == request.Guid);
                if (product == null)
                {
                    throw new Exception("Böyle bir ürün bulunumadı");
                }
                await _productRepository.DeleteAsync(product);
                return _mapper.Map<ProductViewModel>(product);
            }
        }
    }
}
