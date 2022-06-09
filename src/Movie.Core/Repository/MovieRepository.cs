using Movie.Core.Model;
using Movie.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _dbContext;

        public MovieRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MovieEntity>> GetAll()
        {
            return await Task.Run(() => _dbContext.Movie.AsEnumerable());
        }
        public async Task<MovieEntity> FindById(int id)
        {
            var movie = await _dbContext.Movie.FindAsync(id);
            if (movie == null) return null;
            return await _dbContext.Movie.FindAsync(id);
        }
    }
}
