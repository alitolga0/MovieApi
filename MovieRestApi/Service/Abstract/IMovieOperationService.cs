using IResult = MovieRestApi.Core.Utilities.Results.IResult;

namespace MovieRestApi.Service.Abstract
{
    public interface IMovieOperationService
    {
        Task<IResult> AddActors(Guid Id, List<Guid> actorIds);
        Task<IResult> AddCategories(Guid id, List<Guid> categoryIds);
    }
}
