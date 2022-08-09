using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Microsoft.EntityFrameworkCore;
using Plants_Monthly.Exceptions;
using Plants_Monthly.Utils;

namespace Plants_Monthly.DAL
{
    public class OrderStatusDAL : IOrderStatusDAL
    {
        private readonly ILogger<OrderStatusDAL> _logger;
        private readonly FarmsDbContext _dbContext;

        public OrderStatusDAL(
            ILogger<OrderStatusDAL> logger,
            FarmsDbContext dbContext
            )
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<OrderStatus> GetOrderStatusAsync(string name)
        {
            _logger.LogInformation("### OrderStatusDAL - GetOrderStatusAsync started ###");

            OrderStatus? orderStatus = await _dbContext
                .OrderStatuses
                .Where(os => os.Name == name)
                .FirstOrDefaultAsync();

            if (orderStatus == null) throw new OrderNotFoundException($"There is no order status with name {name}");

            _logger.LogInformation("### OrderStatusDAL - GetOrderStatusAsync ended ###");

            return orderStatus;
        }
    }

}
