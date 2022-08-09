
using Plants_Monthly.DTO;
using Plants_Monthly.Model;

namespace Plants_Monthly.DAL.Interfaces
{
    public interface IOrderDAL
    {
        public Task<OrderDTO> GetLastOrderAsync(int userId);
        public Task<Order> GetOrderAsync(int userId, int orderId);
        public Task<OrderDTO> CreateOrderAsync(int userId, OrderDTO orderDTO);
        public Task<OrderDTO> UpdateOrderAsync(Order order, OrderDTO orderDTO);
    }
}
