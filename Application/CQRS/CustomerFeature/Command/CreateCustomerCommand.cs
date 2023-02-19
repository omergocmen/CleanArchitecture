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

namespace Application.CQRS.ProductFeature.Command
{
    public class CreateCustomerCommand : IRequest<CreateCustomerViewModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerViewModel>
        {
            private readonly IMapper _mapper;
            private readonly ICustomerRepository _customerRepository;
            public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _customerRepository = customerRepository;
            }

            public async Task<CreateCustomerViewModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer customer = _mapper.Map<Customer>(request);
                var result = await _customerRepository.AddAsync(customer);
                CreateCustomerViewModel model = _mapper.Map<CreateCustomerViewModel>(result);
                return model;
            }
        }
    }
}
