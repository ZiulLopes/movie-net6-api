using Movie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Services.Interface
{
    public interface IMovieService
    {
        Task<List<MovieEntity>> GetMovies();
        Task<MovieEntity> GetMovieById(int id);
    }
}
