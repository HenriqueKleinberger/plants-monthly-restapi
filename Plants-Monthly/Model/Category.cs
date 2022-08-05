using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class Category
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Plant> Plants { get; set; }
    }
}

