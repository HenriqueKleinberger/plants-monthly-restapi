
using Plants_Monthly.DTO;

namespace Plants_Monthly.BLL.Interfaces
{
    public interface ICategoryBLL
    {
        public Task<List<CategoryDTO>> GetCategoriesAsync();

        //public Task<MovieDetailsResponseDTO> GetMovieDetailsAsync(String imdbId);
    }
}
