using Movie.Core.Model;
using Movie.Core.Repository.Interface;
using Movie.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieEntity>> GetMovies()
        {
            return await _movieRepository.GetAll();
        }

        public async Task<MovieEntity> GetMovieById(int id)
        {
            return await _movieRepository.FindById(id);
        }
    }
}
