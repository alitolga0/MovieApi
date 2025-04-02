using MovieRestApi.Core.Service;
using MovieRestApi.Models;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;

namespace MovieRestApi.Service.Abstract
{
    public interface IMovieService : IBaseService<Movie,Guid>
    {
        Task<IResult> AddActors(Guid Id, List<Guid> actorIds);
    }
}
