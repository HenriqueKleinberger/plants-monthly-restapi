using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Microsoft.EntityFrameworkCore;
using Plants_Monthly.Exceptions;

namespace Plants_Monthly.DAL
{
    public class PushTokenDAL : IPushTokenDAL
    {
        private readonly ILogger<PushTokenDAL> _logger;
        private readonly IOrderDAL _orderDAL;
        private readonly FarmsDbContext _dbContext;

        public PushTokenDAL(
            ILogger<PushTokenDAL> logger,
            FarmsDbContext dbContext,
            IOrderDAL orderDAL
        )
        {
            _logger = logger;
            _dbContext = dbContext;
            _orderDAL = orderDAL;
        }

        public async Task<List<PushTokenDTO>> GetPushTokensAsync()
        {
            _logger.LogInformation("### PushTokenDAL - GetPushTokensAsync started ###");

            List<PushToken> pushTokens = await _dbContext
                .PushTokens
                .Include(pt => pt.User)
                .ThenInclude(u => u.Orders)
                .Where(pt => pt.User.Orders.Any(o => o.Date.Month == DateTime.Now.Month && o.Status.Name == Constants.OrderStatus.OPENED))
                .ToListAsync();

            _logger.LogInformation("### PushTokenDAL - GetPushTokensAsync ended ###");

            return pushTokens.ConvertAll(p => p.ToPushTokenDTO());
        }
    }

}
