using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Microsoft.EntityFrameworkCore;
using Plants_Monthly.Exceptions;

namespace Plants_Monthly.DAL
{
    public class OrderDAL : IOrderDAL
    {
        private readonly ILogger<OrderDAL> _logger;
        private readonly FarmsDbContext _dbContext;

        public OrderDAL(ILogger<OrderDAL> logger, FarmsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<OrderDTO> GetOrderOpenedAsync(int userId)
        {
            _logger.LogInformation("### OrderDAL - GetOrderOpenedAsync started ###");

            Order? order = await _dbContext
                .Orders
                .Where(o => o.User.Id == userId && o.Status == OrderStatus.Opened).FirstOrDefaultAsync();

            if (order == null) throw new OrderNotFoundException("There is no order opened for this user");

            _logger.LogInformation("### OrderDAL - GetOrderOpenedAsync ended ###");

            return order.ToOrderDTO();
        }

    }

}
