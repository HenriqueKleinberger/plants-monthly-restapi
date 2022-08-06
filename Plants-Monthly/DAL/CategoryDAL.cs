using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;
using Plants_Monthly.Mappers;
using Plants_Monthly.Model;
using Microsoft.EntityFrameworkCore;

namespace Plants_Monthly.DAL
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly ILogger<CategoryDAL> _logger;
        private readonly FarmsDbContext _dbContext;

        public CategoryDAL(ILogger<CategoryDAL> logger, FarmsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            _logger.LogInformation("### CategoryDAL - GetCategoriesAsync started ###");

            List<Category> categories = await _dbContext.Categories.Include(c => c.Plants).ToListAsync();

            _logger.LogInformation("### CategoryDAL - GetCategoriesAsync ended ###");

            return categories.ConvertAll(c => c.ToCategoryDTO());
        }
    }

}
