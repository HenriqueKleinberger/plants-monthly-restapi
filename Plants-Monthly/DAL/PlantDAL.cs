using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Microsoft.EntityFrameworkCore;
using Plants_Monthly.Exceptions;

namespace Plants_Monthly.DAL
{
    public class PlantDAL : IPlantDAL
    {
        private readonly ILogger<PlantDAL> _logger;
        private readonly FarmsDbContext _dbContext;

        public PlantDAL(ILogger<PlantDAL> logger, FarmsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<Plant>> GetPlantsAsync(List<string> ids)
        {
            _logger.LogInformation("### PlantDAL - GetPlantsAsync started ###");

            List<Plant> plants = await _dbContext
                .Plants
                .Where(p => ids.Contains(p.Id)).ToListAsync();

            _logger.LogInformation("### PlantDAL - GetPlantsAsync ended ###");

            return plants;
        }
    }

}
