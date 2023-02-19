using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.CategoryDomain;
using Domain.Entities.CustomerDomain;
using Domain.Entities.ProductDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductsFeature.Command
{
    public class DeleteCustomerCommand : IRequest<CustomerViewModel>
    {
        public Guid Guid { get; set; }
        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, CustomerViewModel>
        {
            private readonly IMapper _mapper;
            private readonly ICustomerRepository _customerRepository;
            public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _customerRepository = customerRepository;
            }
            public async Task<CustomerViewModel> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer customer= await _customerRepository.GetAsync(p => p.Guid == request.Guid);
                if (customer == null)
                {
                    throw new Exception("Böyle bir müşteri bulunumadı");
                }
                await _customerRepository.DeleteAsync(customer);
                return _mapper.Map<CustomerViewModel>(customer);
            }
        }
    }
}
