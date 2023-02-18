using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Query;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Entities.Product;
using Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseController
    {
        public ProductController()
        {
        }

        [HttpGet(Name = "getallproducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] PageRequest pageRequest)
        {
            GetAllProductQuery query = new GetAllProductQuery();
            query.PageRequest = pageRequest;
            List<ProductViewModel> products = await Mediator.Send(query);
            return Ok(products);
        }

        [HttpPost(Name = "addproduct")]
        public async Task<IActionResult> AddAsync([FromBody] CreateProductCommand createProductCommand)
        {
            CreateProductViewModel result = await Mediator.Send(createProductCommand);
            return Ok(result);
        }
    }
}