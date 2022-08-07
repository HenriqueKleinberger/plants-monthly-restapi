
using Plants_Monthly.DTO;

namespace Plants_Monthly.BLL.Interfaces
{
    public interface IOrderBLL
    {
        public Task<OrderDTO> GetOrderOpenedAsync(int userId);
        public Task<OrderDTO> CreateOrderAsync(int userId, OrderDTO orderDTO);
    }
}
