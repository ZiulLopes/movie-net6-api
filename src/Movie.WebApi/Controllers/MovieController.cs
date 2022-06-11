using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movie.Core.Model;
using Movie.Core.Request;
using Movie.Core.Response;
using Movie.Core.Services.Interface;

namespace Movie.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MovieController> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<MovieRequest> _validator;

        public MovieController(IMovieService movieService,
            ILogger<MovieController> logger,
            IMapper mapper,
            IValidator<MovieRequest> validator)
        {
            _movieService = movieService;
            _logger = logger;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var movies = await _movieService.GetMovies();
            var _movies = _mapper.Map<List<MovieResponse>>(movies);
            return Ok(_movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null) return NotFound();

            var _movie = _mapper.Map<MovieResponse>(movie);
            return Ok(_movie);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] MovieRequest movie)
        {
            var validator = await _validator.ValidateAsync(movie);
            if (!validator.IsValid) return BadRequest(string.Join(',', validator.Errors.Select(v => v.ErrorMessage)));

            var _movie = _mapper.Map<MovieEntity>(movie);
            if (movie == null) return BadRequest();

            var (movieEntity, saved, message) = await _movieService.AddMovie(_movie);
            _logger.LogInformation(message);

            if (!saved) return BadRequest(message);
            var _movieEntity = _mapper.Map<MovieResponse>(movieEntity);

            return Ok(_movieEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] MovieRequest movie, [FromRoute] int id)
        {
            var validator = await _validator.ValidateAsync(movie);
            if (!validator.IsValid) return BadRequest(string.Join(',', validator.Errors.Select(v => v.ErrorMessage)));

            if ((await _movieService.GetMovieById(id)) == null) return NotFound();
            
            if (movie == null) return BadRequest();
            var _movie = _mapper.Map<MovieEntity>(movie);

            var (movieEntity, saved, message) = await _movieService.UpdateMovie(_movie, id);
            _logger.LogInformation(message);

            if (!saved) return BadRequest(message);
            var _movieEntity = _mapper.Map<MovieResponse>(movieEntity);

            return Ok(_movieEntity);
        }
    }
}
