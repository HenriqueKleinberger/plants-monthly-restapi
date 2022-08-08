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
        private readonly FarmsDbContext _dbContext;

        public PushTokenDAL(ILogger<PushTokenDAL> logger, FarmsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<PushTokenDTO>> GetPushTokensAsync()
        {
            _logger.LogInformation("### PushTokenDAL - GetPushTokensAsync started ###");

            List<PushToken> pushTokens = await _dbContext
                .PushTokens
                .ToListAsync();

            _logger.LogInformation("### PushTokenDAL - GetPushTokensAsync ended ###");

            return pushTokens.ConvertAll(p => p.ToPushTokenDTO());
        }
    }

}
