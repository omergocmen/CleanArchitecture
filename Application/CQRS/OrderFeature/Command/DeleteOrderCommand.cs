using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.CategoryDomain;
using Domain.Entities.OrderDomain;
using Domain.Entities.ProductDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Command
{
    public class DeleteOrderCommand : IRequest<OrderViewModel>
    {
        public Guid Guid { get; set; }
        public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, OrderViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IOrderRepository _orderRepository;
            public DeleteOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
            }
            public async Task<OrderViewModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            {
                Order order= await _orderRepository.GetAsync(p => p.Guid == request.Guid);
                if (order == null)
                {
                    throw new Exception("Böyle bir sipariş bulunumadı");
                }
                await _orderRepository.DeleteAsync(order);
                return _mapper.Map<OrderViewModel>(order);
            }
        }
    }
}
