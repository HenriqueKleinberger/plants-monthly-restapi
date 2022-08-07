
using Plants_Monthly.DTO;
using Plants_Monthly.Model;

namespace Plants_Monthly.DAL.Interfaces
{
    public interface IPlantDAL
    {
        public Task<List<Plant>> GetPlantsAsync(List<string> ids);
    }
}
