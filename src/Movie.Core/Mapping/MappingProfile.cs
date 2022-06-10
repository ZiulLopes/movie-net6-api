using AutoMapper;
using Movie.Core.Model;
using Movie.Core.Request;
using Movie.Core.Response;

namespace Movie.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieRequest, MovieEntity>();
            CreateMap<MovieEntity, MovieResponse>();
        }
    }
}