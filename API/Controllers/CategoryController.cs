using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Command;
using Application.CQRS.ProductsFeature.Query;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Entities.CategoryDomain;
using Domain.Entities.ProductDomain;
using Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : BaseController
    {

        [HttpPost("addcategory")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreateCategoryViewModel result = await Mediator.Send(createCategoryCommand);
            return Ok(result);
        }

        [HttpPost("deletecategory")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            CategoryViewModel result = await Mediator.Send(deleteCategoryCommand);
            return Ok(result);
        }

        [HttpPost("updatecategory")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            CategoryViewModel result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);
        }

        [HttpGet("getallcategories")]
        public async Task<IActionResult> GetAllCategories([FromQuery] PageRequest pageRequest)
        {
            GetAllCategoryQuery query = new GetAllCategoryQuery();
            query.PageRequest = pageRequest;
            List<CategoryViewModel> categories = await Mediator.Send(query);
            return Ok(categories);
        }
    }
}