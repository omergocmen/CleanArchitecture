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
    public class UpdateOrderCommand : IRequest<OrderViewModel>
    {
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IOrderRepository _orderRepository;
            public UpdateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
            }
            public async Task<OrderViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                Order updatedOrder = _mapper.Map<Order>(request);
                await _orderRepository.UpdateAsync(updatedOrder);
                return _mapper.Map<OrderViewModel>(updatedOrder);
            }
        }
    }
}
