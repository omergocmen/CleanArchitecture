using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Command;
using Application.CQRS.ProductsFeature.Query;
using AutoMapper;
using Domain.Entities.CustomerDomain;
using Domain.Entities.ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Profiles
{
    public class CustomerMappingProfiles : Profile
    {
        public CustomerMappingProfiles()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CreateCustomerViewModel>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        }
    }
}
