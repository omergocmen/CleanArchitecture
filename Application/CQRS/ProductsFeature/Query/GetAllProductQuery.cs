using Application.Interfaces.Respositories;
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
            public GetAllProductQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<List<ProductViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                List<ProductViewModel> productViewModels = new List<ProductViewModel>();
                var result = await _productRepository.GetAllWithPaginationAsync(pageRequest: request.PageRequest);

                foreach (var item in result)
                {
                    productViewModels.Add(new ProductViewModel
                    {
                        ProductId = item.Guid,
                        ProductName = item.ProductName,
                        Price = item.Price,
                        Stock = item.Stock,
                        IsActive = item.IsActive
                    });
                }
                return productViewModels;
            }
        }
    }
}
