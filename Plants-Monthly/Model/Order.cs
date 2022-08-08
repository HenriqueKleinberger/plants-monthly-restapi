using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public List<Plant> Plants { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        Opened,
        WaitingDelivery,
        Deliveled,
        Canceled
    }
}

