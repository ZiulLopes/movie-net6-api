using Movie.Core.Model;
using Movie.Core.Repository.Interface;
using Movie.Core.Services.Interface;

namespace Movie.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieEntity>> GetMovies()
        {
            return await _movieRepository.GetAll();
        }

        public async Task<MovieEntity> GetMovieById(int id)
        {
            return await _movieRepository.FindById(id);
        }

        public async Task<(MovieEntity, bool, string)> AddMovie(MovieEntity movie)
        {
            return await _movieRepository.AddMovie(movie);
        }

        public async Task<(MovieEntity, bool, string)> UpdateMovie(MovieEntity movie, int id)
        {
            return await _movieRepository.UpdateMovie(movie, id);
        }
    }
}
