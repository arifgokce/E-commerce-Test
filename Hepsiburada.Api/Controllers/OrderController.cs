using Hepsiburada.Business.Interface.Operation;
using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hepsiburada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderOperation _orderOperation;
        public OrderController(IOrderOperation orderOperation)
        {
            _orderOperation = orderOperation;
        }

        [HttpPost("Create-Order")]
        public IActionResult CreateOrder(CreateOrderModel createOrderModel)
        {
            Response<string> result = _orderOperation.CreateOrder(createOrderModel);
            if (result.Successful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
