using Movie.Core.Model;
using Movie.Core.Request;

namespace Movie.Core.Services.Interface
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieEntity>> GetMovies();
        Task<MovieEntity> GetMovieById(int id);
        Task<(MovieEntity, bool, string)> AddMovie(MovieEntity movie);
        Task<(MovieEntity, bool, string)> UpdateMovie(MovieEntity movie, int id);
        Task<bool> Remove(MovieEntity movie);
        Task<IEnumerable<MovieEntity>> GetSQLMovies();
    }
}
