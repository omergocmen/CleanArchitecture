using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.CategoryDomain;
using Domain.Entities.ProductDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductFeature.Command
{
    public class CreateCategoryCommand : IRequest<CreateCategoryViewModel>
    {
        public string CategoryName { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryViewModel>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;
            public CreateProductCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
            }

            public async Task<CreateCategoryViewModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category category = _mapper.Map<Category>(request);
                var result = await _categoryRepository.AddAsync(category);
                CreateCategoryViewModel model = _mapper.Map<CreateCategoryViewModel>(result);
                return model;
            }
        }
    }
}
