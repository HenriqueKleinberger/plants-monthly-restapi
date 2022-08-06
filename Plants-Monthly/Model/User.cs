using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}

