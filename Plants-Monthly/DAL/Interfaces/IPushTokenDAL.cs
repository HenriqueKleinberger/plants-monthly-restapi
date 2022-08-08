
using Plants_Monthly.DTO;
using Plants_Monthly.Model;

namespace Plants_Monthly.DAL.Interfaces
{
    public interface IPushTokenDAL
    {
        public Task<List<PushTokenDTO>> GetPushTokensAsync();
    }
}
