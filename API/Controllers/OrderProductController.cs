using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Command;
using Application.CQRS.ProductsFeature.Query;
using Domain.Entities.OrderDomain;
using Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderProductController : BaseController
    {

        [HttpPost("addorderproduct")]
        public async Task<IActionResult> AddAsync([FromBody] CreateOrderProductCommand createOrderProductCommand)
        {
            CreateOrderProductViewModel result = await Mediator.Send(createOrderProductCommand);
            return Ok(result);
        }

        [HttpPost("deleteorderproduct")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteOrderProductCommand deleteOrderProductCommand)
        {
            OrderProductViewModel result = await Mediator.Send(deleteOrderProductCommand);
            return Ok(result);
        }

        [HttpPost("updateorderproduct")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOrderProductCommand updateOrderProductCommand)
        {
            OrderProductViewModel result = await Mediator.Send(updateOrderProductCommand);
            return Ok(result);
        }

        [HttpGet("getallorderproducts")]
        public async Task<IActionResult> GetAllCategories([FromQuery] PageRequest pageRequest)
        {
            GetAllOrderProductQuery query = new GetAllOrderProductQuery();
            query.PageRequest = pageRequest;
            List<OrderProductViewModel> OrderProducts = await Mediator.Send(query);
            return Ok(OrderProducts);
        }
    }
}