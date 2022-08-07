
using Plants_Monthly.DTO;
using Plants_Monthly.Model;

namespace Plants_Monthly.DAL.Interfaces
{
    public interface IUserDAL
    {
        public Task<User> GetUserAsync(int userId);
    }
}
