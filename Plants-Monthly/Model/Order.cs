using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

        public OrderStatus Category { get; set; }
    }

    public enum OrderStatus
    {
        Deliveled,
        Opened,
        WaitingDelivery
    }
}

