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
        public async Task<IActionResult> Review(string id)
        {
            var foundMovie = await _movieService.GetMovieById(id);
            return View(foundMovie);
        }
    }
}
