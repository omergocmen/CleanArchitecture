using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Command;
using Application.CQRS.ProductsFeature.Query;
using AutoMapper;
using Domain.Entities.ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Profiles
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, CreateProductViewModel>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}
