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

namespace Application.CQRS.ProductFeature.Command
{
    public class CreateOrderCommand : IRequest<CreateOrderViewModel>
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid CustomerId { get; set; }
        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IOrderRepository _orderRepository;
            public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
            {
                _mapper = mapper;
                _orderRepository = orderRepository;
            }

            public async Task<CreateOrderViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                Order order = _mapper.Map<Order>(request);
                var result = await _orderRepository.AddAsync(order);
                CreateOrderViewModel model = _mapper.Map<CreateOrderViewModel>(result);
                return model;
            }
        }
    }
}
