using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.CategoryDomain;
using Domain.Entities.CustomerDomain;
using Domain.Entities.ProductDomain;
using Domain.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Query
{
    public class GetAllCustomerQuery : IRequest<List<CustomerViewModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerViewModel>>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }
            public async Task<List<CustomerViewModel>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                var result = await _customerRepository.GetAllWithPaginationAsync(pageRequest: request.PageRequest);
                List<CustomerViewModel> customerViewModels = _mapper.Map<List<CustomerViewModel>>(result);
                return customerViewModels;
            }
        }
    }
}
