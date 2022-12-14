using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}

