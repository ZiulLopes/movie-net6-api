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
        public Task<IEnumerable<MovieEntity>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<MovieEntity>> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
