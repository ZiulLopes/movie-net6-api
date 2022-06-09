using Movie.Core.Model;

namespace Movie.Core.Repository.Interface
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieEntity>> GetAll();
        Task<MovieEntity> FindById(int id);
    }
}
