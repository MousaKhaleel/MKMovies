using System.ComponentModel.DataAnnotations.Schema;

namespace MKMovies.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string content { get; set; }

        //nav prop
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
