using Microsoft.AspNetCore.Mvc;
using Movie.Core.Model;

namespace Movie.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var movies = new List<MovieEntity>() {
                new MovieEntity() {
                    Title = "My movie", 
                    Id = 1 
                }
            };
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var movies = new List<MovieEntity>() {
                new MovieEntity() {
                    Title = "My movie",
                    Id = 1
                }
            };
            return Ok(movies);
        }
    }
}
