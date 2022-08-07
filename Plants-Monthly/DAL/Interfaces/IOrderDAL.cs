
using Plants_Monthly.DTO;

namespace Plants_Monthly.DAL.Interfaces
{
    public interface IOrderDAL
    {
        public Task<OrderDTO> GetOrderOpenedAsync(int userId);

        Task<OrderDTO> CreateOrderAsync(int userId, OrderDTO orderDTO);
    }
}
