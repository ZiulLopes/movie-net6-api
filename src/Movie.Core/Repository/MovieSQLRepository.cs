using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Movie.Core.Model;
using Movie.Core.Repository.Interface;

namespace Movie.Core.Repository
{
    public class MovieSQLRepository : IMovieSQLRepository
    {
        private readonly IConfiguration _configuration;
        private const string ConnectionString = "MOVIEDB01";

        public MovieSQLRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<MovieEntity>> GetAll()
        {
            var db = new SqlConnection(_configuration.GetConnectionString(ConnectionString));
            var query = @"SELECT * FROM MOVIE
                          WHERE 1 = 1";
            return await db.QueryAsync<MovieEntity>(query);
        }

        public Task<MovieEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<(MovieEntity, bool, string)> AddMovie(MovieEntity movie)
        {
            throw new NotImplementedException();
        }

        public Task<(MovieEntity, bool, string)> UpdateMovie(MovieEntity movie, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(MovieEntity movie)
        {
            throw new NotImplementedException();
        }
    }
}
