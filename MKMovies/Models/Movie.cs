namespace MKMovies.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public string ImageUrl { get; set; }
        public string Rating { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
