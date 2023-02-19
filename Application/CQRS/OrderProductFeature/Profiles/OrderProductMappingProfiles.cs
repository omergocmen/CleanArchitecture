using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Command;
using AutoMapper;
using Domain.Entities.OrderDomain;

namespace Application.CQRS.ProductsFeature.Profiles
{
    public class OrderProductMappingProfiles : Profile
    {
        public OrderProductMappingProfiles()
        {
            CreateMap<OrderProduct, OrderProductViewModel>().ReverseMap();
            CreateMap<OrderProduct, CreateOrderProductViewModel>().ReverseMap();
            CreateMap<OrderProduct, CreateOrderProductCommand>().ReverseMap();
            CreateMap<OrderProduct, UpdateOrderProductCommand>().ReverseMap();
        }
    }
}
