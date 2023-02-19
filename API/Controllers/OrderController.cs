using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Command;
using Application.CQRS.ProductsFeature.Query;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Entities.CategoryDomain;
using Domain.Entities.OrderDomain;
using Domain.Entities.ProductDomain;
using Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : BaseController
    {

        [HttpPost("addorder")]
        public async Task<IActionResult> AddAsync([FromBody] CreateOrderCommand createOrderCommand)
        {
            CreateOrderViewModel result = await Mediator.Send(createOrderCommand);
            return Ok(result);
        }

        [HttpPost("deleteorder")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteOrderCommand deleteOrderCommand)
        {
            OrderViewModel result = await Mediator.Send(deleteOrderCommand);
            return Ok(result);
        }

        [HttpPost("updateorder")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOrderCommand updateOrderCommand)
        {
            OrderViewModel result = await Mediator.Send(updateOrderCommand);
            return Ok(result);
        }

        [HttpGet("getallorders")]
        public async Task<IActionResult> GetAllCategories([FromQuery] PageRequest pageRequest)
        {
            GetAllOrderQuery query = new GetAllOrderQuery();
            query.PageRequest = pageRequest;
            List<OrderViewModel> orders = await Mediator.Send(query);
            return Ok(orders);
        }
    }
}