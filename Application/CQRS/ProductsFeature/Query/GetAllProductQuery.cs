using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.Product;
using Domain.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Query
{
    public class GetAllProductQuery : IRequest<List<ProductViewModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductViewModel>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetAllProductQueryHandler(IProductRepository productRepository,IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }
            public async Task<List<ProductViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var result = await _productRepository.GetAllWithPaginationAsync(pageRequest: request.PageRequest);
                List<ProductViewModel> productViewModels = _mapper.Map<List<ProductViewModel>>(result);
                return productViewModels;
            }
        }
    }
}
