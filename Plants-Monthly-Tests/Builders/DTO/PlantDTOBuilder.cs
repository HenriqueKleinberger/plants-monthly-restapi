using Plants_Monthly.DTO;

namespace Plants_Monthly_Tests.Builders.DTO
{
    public class PlantDTOBuilder
    {


        private PlantDTO _plantDTO;

        public string Name = "Plant Name";
        public string ImageId = "Image Id";
        public string Id = "Id";

        public PlantDTOBuilder()
        {
            _plantDTO = new PlantDTO();
            _plantDTO.Name = this.Name;
            _plantDTO.ImageId = this.ImageId;
            _plantDTO.Id = this.Id;
        }
        public PlantDTOBuilder WithName(string name)
        {
            _plantDTO.Name = name;
            return this;
        }

        public PlantDTOBuilder WithImageId(string imageId)
        {
            _plantDTO.ImageId = imageId;
            return this;
        }

        public PlantDTOBuilder WithId(string id)
        {
            _plantDTO.Id = id;
            return this;
        }

        public PlantDTO Build()
        {
            return _plantDTO;
        }
    }
}
