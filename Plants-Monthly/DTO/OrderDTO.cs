namespace Plants_Monthly.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public List<PlantDTO> Plants { get; set; }
        public string? Status { get; set; }
    }
}

