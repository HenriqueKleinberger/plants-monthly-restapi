using Microsoft.AspNetCore.Mvc;
using Plants_Monthly.BLL.Interfaces;
using Plants_Monthly.DTO;
using Plants_Monthly.Exceptions;

namespace Plants_Monthly.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IOrderBLL _orderBLL;

        public OrderController(ILogger<OrderController> logger, IOrderBLL orderBLL)
        {
            _logger = logger;
            _orderBLL = orderBLL;
        }

        [HttpGet("userId/{userId}/opened", Name = "GetOrders")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                OrderDTO orderDTO = await _orderBLL.GetOrderOpenedAsync(userId);
                return Ok(orderDTO);
            } catch (OrderNotFoundException Exception)
            {
                return Ok(null);
            }
        }

        [HttpPost("userId/{userId}", Name = "Create Order")]
        public async Task<IActionResult> Post(int userId, [FromBody] OrderDTO orderDTO)
        {
            OrderDTO orderDTOCreated = await _orderBLL.CreateOrderAsync(userId, orderDTO);
            return Created("PostAsync", orderDTOCreated);
        }
    }
}