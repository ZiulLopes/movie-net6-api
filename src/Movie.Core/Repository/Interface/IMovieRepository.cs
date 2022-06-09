using Movie.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Core.Repository.Interface
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieEntity>> GetAll();
        Task<IEnumerable<MovieEntity>> FindById(int id);
    }
}
