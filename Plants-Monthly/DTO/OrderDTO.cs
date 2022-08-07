namespace Plants_Monthly.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<String> PlantsId { get; set; }
    }
}

