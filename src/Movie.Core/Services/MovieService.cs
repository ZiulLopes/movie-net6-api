using Movie.Core.Model;
using Movie.Core.Repository.Interface;
using Movie.Core.Services.Interface;

namespace Movie.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieSQLRepository _movieSQLRepository;

        public MovieService(IMovieRepository movieRepository, IMovieSQLRepository movieSQLRepository)
        {
            _movieRepository = movieRepository;
            _movieSQLRepository = movieSQLRepository;
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

        public async Task<bool> Remove(MovieEntity movie)
        {
            return await _movieRepository.Delete(movie);
        }

        public async Task<IEnumerable<MovieEntity>> GetSQLMovies()
        {
            return await _movieSQLRepository.GetAll();
        }
    }
}
