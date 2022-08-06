namespace Plants_Monthly.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<PlantDTO> Plants { get; set; }
    }
}

