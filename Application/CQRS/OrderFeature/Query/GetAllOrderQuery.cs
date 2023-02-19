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
    public class GetAllOrderQuery : IRequest<List<OrderViewModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderViewModel>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }
            public async Task<List<OrderViewModel>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
            {
                var result = await _orderRepository.GetAllWithPaginationAsync(pageRequest: request.PageRequest);
                List<OrderViewModel> orderViewModels = _mapper.Map<List<OrderViewModel>>(result);
                return orderViewModels;
            }
        }
    }
}
