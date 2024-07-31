using Microsoft.AspNetCore.Mvc;
using MKMovies.Services;

namespace MKMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;
        public MoviesController()
        {
            _movieService = new MovieService();
        }
        public async Task<IActionResult> Popular()
        {
            var movies = await _movieService.GetPopular();
            return View(movies);
        }
        public async Task<IActionResult> Review(string Title)
        {
            var foundMovie = await _movieService.GetMovieByName(Title);
            return View(foundMovie);
        }
    }
}
