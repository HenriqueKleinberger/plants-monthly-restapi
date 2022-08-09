using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class Plant
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageId { get; set; }
        public Category Category { get; set; }

        public List<OrderPlants> OrderPlants { get; set; }
    }
}

