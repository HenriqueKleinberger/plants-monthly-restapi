
using Plants_Monthly.DTO;
using Plants_Monthly.Model;

namespace Plants_Monthly.Mappers
{
    public static class PlantMapper
    {
        public static PlantDTO ToPlantDTO(this Plant plant)
        {
            PlantDTO plantDTO = new PlantDTO()
            {
                Id = plant.Id,
                ImageId = plant.ImageId,
                Name = plant.Name
            };

            return plantDTO;
        }
    }
}
