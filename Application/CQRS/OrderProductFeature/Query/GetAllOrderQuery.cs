using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.CategoryDomain;
using Domain.Entities.OrderDomain;
using Domain.Entities.ProductDomain;
using Domain.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Query
{
    public class GetAllOrderProductQuery : IRequest<List<OrderProductViewModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllOrderProductQueryHandler : IRequestHandler<GetAllOrderProductQuery, List<OrderProductViewModel>>
        {
            private readonly IOrderProductRepository _orderProductRepository;
            private readonly IMapper _mapper;
            public GetAllOrderProductQueryHandler(IOrderProductRepository orderProductRepository, IMapper mapper)
            {
                _orderProductRepository = orderProductRepository;
                _mapper = mapper;
            }
            public async Task<List<OrderProductViewModel>> Handle(GetAllOrderProductQuery request, CancellationToken cancellationToken)
            {
                var result = await _orderProductRepository.GetAllWithPaginationAsync(pageRequest: request.PageRequest);
                List<OrderProductViewModel> orderProductViewModels = _mapper.Map<List<OrderProductViewModel>>(result);
                return orderProductViewModels;
            }
        }
    }
}
