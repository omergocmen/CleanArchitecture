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
    public class CreateOrderProductCommand : IRequest<CreateOrderProductViewModel>
    {
        public Guid OrderId { get; set; }
        public Guid  ProductId { get; set; }
        public class CreateOrderProductCommandHandler : IRequestHandler<CreateOrderProductCommand, CreateOrderProductViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _orderProductRepository;
            public CreateOrderProductCommandHandler(IMapper mapper, IOrderProductRepository orderProductRepository)
            {
                _mapper = mapper;
                _orderProductRepository = orderProductRepository;
            }

            public async Task<CreateOrderProductViewModel> Handle(CreateOrderProductCommand request, CancellationToken cancellationToken)
            {
                OrderProduct orderProduct = _mapper.Map<OrderProduct>(request);
                var result = await _orderProductRepository.AddAsync(orderProduct);
                CreateOrderProductViewModel model = _mapper.Map<CreateOrderProductViewModel>(result);
                return model;
            }
        }
    }
}
