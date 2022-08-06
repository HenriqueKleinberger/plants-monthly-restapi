using Plants_Monthly.BLL.Interfaces;
using Plants_Monthly.DAL.Interfaces;
using Plants_Monthly.DTO;

namespace Plants_Monthly.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ILogger<CategoryBLL> _logger;
        private readonly ICategoryDAL _categoryDAL;

        public CategoryBLL(ILogger<CategoryBLL> logger, ICategoryDAL categoryDAL)
        {
            _logger = logger;
            _categoryDAL = categoryDAL;
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            return await _categoryDAL.GetCategoriesAsync();
        }
    }

}
