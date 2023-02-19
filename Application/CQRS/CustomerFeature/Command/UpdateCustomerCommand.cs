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
    public class UpdateCustomerCommand : IRequest<CustomerViewModel>
    {
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerViewModel>
        {
            private readonly IMapper _mapper;
            private readonly ICustomerRepository _customerRepository;
            public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _customerRepository = customerRepository;
            }

            public async Task<CustomerViewModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer updatedCustomer = _mapper.Map<Customer>(request);
                await _customerRepository.UpdateAsync(updatedCustomer);
                return _mapper.Map<CustomerViewModel>(updatedCustomer);
            }
        }
    }
}
