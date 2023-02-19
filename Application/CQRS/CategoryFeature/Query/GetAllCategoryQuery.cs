using Application.Interfaces.Respositories;
using AutoMapper;
using Domain.Entities.CategoryDomain;
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
    public class GetAllCategoryQuery : IRequest<List<CategoryViewModel>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryViewModel>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<List<CategoryViewModel>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var result = await _categoryRepository.GetAllWithPaginationAsync(pageRequest: request.PageRequest);
                List<CategoryViewModel> categoryViewModels = _mapper.Map<List<CategoryViewModel>>(result);
                return categoryViewModels;
            }
        }
    }
}
