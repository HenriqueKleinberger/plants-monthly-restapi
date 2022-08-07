using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Microsoft.EntityFrameworkCore;
using Plants_Monthly.Exceptions;

namespace Plants_Monthly.DAL
{
    public class UserDAL : IUserDAL
    {
        private readonly ILogger<UserDAL> _logger;
        private readonly FarmsDbContext _dbContext;

        public UserDAL(ILogger<UserDAL> logger, FarmsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            _logger.LogInformation("### UserDAL - GetUserAsync started ###");

            User? user = await _dbContext
                .Users
                .Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user == null) throw new UserNotFoundException($"There is no user with {userId} id");

            _logger.LogInformation("### UserDAL - GetUserAsync ended ###");

            return user;
        }
    }

}
