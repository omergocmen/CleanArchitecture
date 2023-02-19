using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.OrderDomain;
using MediatR;

namespace Application.CQRS.ProductsFeature.Command
{
    public class UpdateOrderProductCommand : IRequest<OrderProductViewModel>
    {
        public Guid Guid { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public class UpdateOrderProductCommandHandler : IRequestHandler<UpdateOrderProductCommand, OrderProductViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _orderProductRepository;
            public UpdateOrderProductCommandHandler(IMapper mapper, IOrderProductRepository orderProductRepository)
            {
                _mapper = mapper;
                _orderProductRepository = orderProductRepository;
            }
            public async Task<OrderProductViewModel> Handle(UpdateOrderProductCommand request, CancellationToken cancellationToken)
            {
                OrderProduct updatedOrderProduct = _mapper.Map<OrderProduct>(request);
                await _orderProductRepository.UpdateAsync(updatedOrderProduct);
                return _mapper.Map<OrderProductViewModel>(updatedOrderProduct);
            }
        }
    }
}
