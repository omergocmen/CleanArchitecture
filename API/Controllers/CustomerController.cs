using Application.CQRS.ProductFeature.Command;
using Application.CQRS.ProductsFeature.Command;
using Application.CQRS.ProductsFeature.Query;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Entities.CategoryDomain;
using Domain.Entities.CustomerDomain;
using Domain.Entities.ProductDomain;
using Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {

        [HttpPost("addcustomer")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            CreateCustomerViewModel result = await Mediator.Send(createCustomerCommand);
            return Ok(result);
        }

        [HttpPost("deletecustomer")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCustomerCommand deleteCustomerCommand)
        {
            CustomerViewModel result = await Mediator.Send(deleteCustomerCommand);
            return Ok(result);
        }

        [HttpPost("updatecustomer")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            CustomerViewModel result = await Mediator.Send(updateCustomerCommand);
            return Ok(result);
        }

        [HttpGet("getallcustomers")]
        public async Task<IActionResult> GetAllCategories([FromQuery] PageRequest pageRequest)
        {
            GetAllCustomerQuery query = new GetAllCustomerQuery();
            query.PageRequest = pageRequest;
            List<CustomerViewModel> categories = await Mediator.Send(query);
            return Ok(categories);
        }
    }
}