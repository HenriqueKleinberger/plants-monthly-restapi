
using Plants_Monthly.DTO;

namespace Plants_Monthly.DAL.Interfaces
{
    public interface ICategoryDAL
    {
        public Task<List<CategoryDTO>> GetCategoriesAsync();
    }
}
