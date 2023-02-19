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
    public class DeleteCategoryCommand : IRequest<CategoryViewModel>
    {
        public Guid Guid { get; set; }
        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryViewModel>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<CategoryViewModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                Category category= await _categoryRepository.GetAsync(p => p.Guid == request.Guid);
                if (category == null)
                {
                    throw new Exception("Böyle bir kategori bulunumadı");
                }
                await _categoryRepository.DeleteAsync(category);
                return _mapper.Map<CategoryViewModel>(category);
            }
        }
    }
}
