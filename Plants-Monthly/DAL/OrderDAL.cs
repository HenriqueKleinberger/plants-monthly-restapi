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
        private readonly IPlantDAL _plantDAL;
        private readonly IUserDAL _userDAL;

        public OrderDAL(
            ILogger<OrderDAL> logger,
            FarmsDbContext dbContext,
            IPlantDAL plantDAL,
            IUserDAL userDAL
            )
        {
            _logger = logger;
            _dbContext = dbContext;
            _plantDAL = plantDAL;
            _userDAL = userDAL;
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

        public async Task<OrderDTO> CreateOrderAsync(int userId, OrderDTO orderDTO)
        {
            _logger.LogInformation("### CategoryDAL - GetCategoriesAsync started ###");

            List<Plant> plants = await _plantDAL.GetPlantsAsync(orderDTO.PlantsId);
            User user = await _userDAL.GetUserAsync(userId);

            Order order = (await _dbContext.AddAsync(orderDTO.ToOrder(user, plants))).Entity;

            await _dbContext.SaveChangesAsync();

            return order.ToOrderDTO();
        }
    }

}
