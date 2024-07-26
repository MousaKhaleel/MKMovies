using System.ComponentModel.DataAnnotations;

namespace MKMovies.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }
        public string Email { get; set; }

        [MinLength(8)]
        public string Password { get; set; }
    }
}
