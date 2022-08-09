using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class OrderPlants
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }


        public string PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}

