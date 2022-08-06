
using Plants_Monthly.DTO;
using Plants_Monthly.Model;

namespace Plants_Monthly.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToCategoryDTO(this Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Plants = category.Plants.ConvertAll(p => p.ToPlantDTO())
            };

            return categoryDTO;
        }
    }
}
