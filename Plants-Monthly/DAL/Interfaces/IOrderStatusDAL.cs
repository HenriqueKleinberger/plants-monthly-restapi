
using Plants_Monthly.Model;

namespace Plants_Monthly.DAL.Interfaces
{
    public interface IOrderStatusDAL
    {
        public Task<OrderStatus> GetOrderStatusAsync(string name);
    }
}
