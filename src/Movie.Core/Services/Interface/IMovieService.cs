using Movie.Core.Model;

namespace Movie.Core.Services.Interface
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieEntity>> GetMovies();
        Task<MovieEntity> GetMovieById(int id);
    }
}
