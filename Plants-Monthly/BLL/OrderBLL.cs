using Plants_Monthly.BLL.Interfaces;
using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;

namespace Plants_Monthly.BLL
{
    public class OrderBLL : IOrderBLL
    {
        private readonly ILogger<OrderBLL> _logger;
        private readonly IOrderDAL _orderDAL;

        public OrderBLL(ILogger<OrderBLL> logger, IOrderDAL orderDAL)
        {
            _logger = logger;
            _orderDAL = orderDAL;
        }

        public async Task<OrderDTO> GetOrderOpenedAsync(int userId)
        {
            return await _orderDAL.GetOrderOpenedAsync(userId);
        }

        public async Task<OrderDTO> CreateOrderAsync(int userId, OrderDTO orderDTO)
        {
            return await _orderDAL.CreateOrderAsync(userId, orderDTO);
        }
    }

}
