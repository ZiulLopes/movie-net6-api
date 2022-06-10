using Microsoft.AspNetCore.Mvc;
using Movie.Core.Model;
using Movie.Core.Services.Interface;

namespace Movie.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovieService movieService, ILogger<MovieController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        // TODO fazer o automapper
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var movies = await _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null) return NotFound();

            return Ok(movie);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] MovieEntity movie)
        {
            if (movie == null) return BadRequest();
            var (_movie, saved, message) = await _movieService.AddMovie(movie);
            _logger.LogInformation(message);
            if (!saved) return BadRequest(message);
            return Ok(_movie);
        }
    }
}
