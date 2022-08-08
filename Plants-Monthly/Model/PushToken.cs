using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class PushToken
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public User User { get; set; }
    }
}

