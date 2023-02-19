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

namespace Application.CQRS.ProductsFeature.Command
{
    public class UpdateCategoryCommand : IRequest<CategoryViewModel>
    {
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryViewModel>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CategoryViewModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category updatedCateogry = _mapper.Map<Category>(request);
                await _categoryRepository.UpdateAsync(updatedCateogry);
                return _mapper.Map<CategoryViewModel>(updatedCateogry);
            }
        }
    }
}
