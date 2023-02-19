using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Command;
using Application.CQRS.ProductsFeature.Query;
using AutoMapper;
using Domain.Entities.CategoryDomain;
using Domain.Entities.OrderDomain;
using Domain.Entities.ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Profiles
{
    public class OrderMappingProfiles : Profile
    {
        public OrderMappingProfiles()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Order, CreateOrderViewModel>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
