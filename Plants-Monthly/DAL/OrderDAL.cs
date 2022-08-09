using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Microsoft.EntityFrameworkCore;
using Plants_Monthly.Exceptions;
using Plants_Monthly.Utils;

namespace Plants_Monthly.DAL
{
    public class OrderDAL : IOrderDAL
    {
        private readonly ILogger<OrderDAL> _logger;
        private readonly FarmsDbContext _dbContext;
        private readonly IPlantDAL _plantDAL;
        private readonly IUserDAL _userDAL;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IOrderStatusDAL _orderStatusDAL;

        public OrderDAL(
            ILogger<OrderDAL> logger,
            FarmsDbContext dbContext,
            IPlantDAL plantDAL,
            IUserDAL userDAL,
            IDateTimeProvider dateTimeProvider,
            IOrderStatusDAL orderStatusDAL
            )
        {
            _logger = logger;
            _dbContext = dbContext;
            _plantDAL = plantDAL;
            _userDAL = userDAL;
            _dateTimeProvider = dateTimeProvider;
            _orderStatusDAL = orderStatusDAL;
        }
        public async Task<Order> GetOrderAsync(int userId, int orderId)
        {
            _logger.LogInformation("### OrderDAL - GetOrderOpenedAsync started ###");

            Order? order = await _dbContext
                .Orders
                .Where(o => o.Id == orderId && o.User.Id == userId)
                .Include(o => o.OrderPlants)
                .Include(o => o.Status)
                .FirstOrDefaultAsync();

            if (order == null) throw new OrderNotFoundException($"There is no order with id {orderId} for the user {userId}");

            _logger.LogInformation("### OrderDAL - GetOrderOpenedAsync ended ###");

            return order;
        }


        public async Task<OrderDTO> GetLastOrderAsync(int userId)
        {
            _logger.LogInformation("### OrderDAL - GetLastOrderAsync started ###");

            Order? order = await _dbContext
                .Orders
                .Where(o => o.User.Id == userId && o.Status.Name == Constants.OrderStatus.OPENED)
                .Include(o => o.OrderPlants)
                .ThenInclude(o => o.Plant)
                .Include(o => o.Status)
                .OrderByDescending(o => o.Date)
                .FirstOrDefaultAsync();

            if (order == null) throw new OrderNotFoundException($"There is no order for the user {userId}");

            _logger.LogInformation("### OrderDAL - GetLastOrderAsync ended ###");

            return order.ToOrderDTO();
        }

        public async Task<OrderDTO> CreateOrderAsync(int userId, OrderDTO orderDTO)
        {
            _logger.LogInformation("### OrderDAL - CreateOrderAsync started ###");

            List<Plant> plants = await _plantDAL.GetPlantsAsync(orderDTO.Plants.ConvertAll(p => p.Id));
            User user = await _userDAL.GetUserAsync(userId);
            OrderStatus orderStatus = await _orderStatusDAL.GetOrderStatusAsync(Constants.OrderStatus.OPENED);
            Order order = orderDTO.ToOrder(user, _dateTimeProvider, orderStatus);
            order.OrderPlants = orderDTO.Plants.ConvertAll(p => new OrderPlants()
            {
                Order = order,
                Plant = plants.Find(pl => pl.Id == p.Id),
            });


            Order entity = (await _dbContext.AddAsync(order)).Entity;

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("### OrderDAL - CreateOrderAsync ended ###");

            return order.ToOrderDTO();
        }

        public async Task<OrderDTO> UpdateOrderAsync(Order order, OrderDTO orderDTO)
        {
            _logger.LogInformation("### OrderDAL - UpdateOrderAsync started ###");

            List<Plant> plants = await _plantDAL.GetPlantsAsync(orderDTO.Plants.ConvertAll(p => p.Id));

            order.OrderPlants = orderDTO.Plants.ConvertAll(p => new OrderPlants()
            {
                Order = order,
                Plant = plants.Find(pl => pl.Id == p.Id),
            });

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("### OrderDAL - UpdateOrderAsync ended ###");

            return order.ToOrderDTO();
        }
    }

}
