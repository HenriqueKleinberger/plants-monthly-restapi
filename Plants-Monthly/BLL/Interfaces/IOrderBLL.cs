
using Plants_Monthly.DTO;

namespace Plants_Monthly.BLL.Interfaces
{
    public interface IOrderBLL
    {
        public Task<OrderDTO> GetLastOrderAsync(int userId);
        public Task<OrderDTO> CreateOrderAsync(int userId, OrderDTO orderDTO);
        public Task<OrderDTO> UpdateOrderAsync(int userId, int orderId, OrderDTO orderDTO);
    }
}
