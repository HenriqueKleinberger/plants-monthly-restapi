namespace Plants_Monthly.DTO
{
    public class CategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<PlantDTO> Plants{ get; set; }
    }
}

