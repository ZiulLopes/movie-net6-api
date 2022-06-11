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
            return movie;
        }

        public async Task<(MovieEntity, bool, string)> AddMovie(MovieEntity movie)
        {
            try
            {
                var _movieEntity = await _dbContext.Movie.AddAsync(movie);
                _dbContext.SaveChanges();
                return (_movieEntity.Entity, true, "movie saved!");
            }
            catch (Exception ex)
            {
                return await Task.Run(() => (movie, false, $"error on save movie: {ex.Message}"));
            }
        }

        public async Task<(MovieEntity, bool, string)> UpdateMovie(MovieEntity movie, int id)
        {
            try
            {
                var _movie = await _dbContext.Movie.FindAsync(id);
                _movie.Title = movie.Title;
                _movie.DateAdd = movie.DateAdd;
                _movie.Year = movie.Year;
                _movie.Duration = movie.Duration;
                _movie.Rate = movie.Rate;
                _movie.Description = movie.Description;
                await _dbContext.SaveChangesAsync();
                return (_movie, true, "movie saved!");
            }
            catch (Exception ex)
            {
                return await Task.Run(() => (movie, false, $"error on update movie: {ex.Message}"));
            }
        }
    }
}
