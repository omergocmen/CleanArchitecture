using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.OrderDomain;
using MediatR;

namespace Application.CQRS.ProductsFeature.Command
{
    public class DeleteOrderProductCommand : IRequest<OrderProductViewModel>
    {
        public Guid Guid { get; set; }
        public class DeleteOrderProductCommandHandler : IRequestHandler<DeleteOrderProductCommand, OrderProductViewModel>
        {
            private readonly IMapper _mapper;
            private readonly IOrderProductRepository _orderProductRepository;
            public DeleteOrderProductCommandHandler(IMapper mapper, IOrderProductRepository orderProductRepository)
            {
                _mapper = mapper;
                _orderProductRepository = orderProductRepository;
            }
            public async Task<OrderProductViewModel> Handle(DeleteOrderProductCommand request, CancellationToken cancellationToken)
            {
                OrderProduct orderProduct= await _orderProductRepository.GetAsync(p => p.Guid == request.Guid);
                if (orderProduct == null)
                {
                    throw new Exception("Böyle bir ürün - sipariş bulunumadı");
                }
                await _orderProductRepository.DeleteAsync(orderProduct);
                return _mapper.Map<OrderProductViewModel>(orderProduct);
            }
        }
    }
}
