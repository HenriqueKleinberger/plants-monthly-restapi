using System.ComponentModel.DataAnnotations;

namespace Plants_Monthly.Model
{
    public class PushToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
    }
}

