using Microsoft.AspNetCore.Mvc;
using MovieRestApi.Service.Abstract;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieOperationController : ControllerBase
    {
        private readonly IMovieOperationService _movieOperationService;

        public MovieOperationController(IMovieOperationService movieOperationService)
        {
            _movieOperationService = movieOperationService;
        }

        [HttpPost("AddActors")]
        public async Task<IResult> AddActors(Guid id, List<Guid> actorIds)
        {
            return await _movieOperationService.AddActors(id, actorIds);
        }

        [HttpPost("AddCategories")]
        public async Task<IResult> AddCategories(Guid id, List<Guid> categoryIds)
        {
            return await _movieOperationService.AddCategories(id, categoryIds);
        }
    }
}
