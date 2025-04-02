using Microsoft.AspNetCore.Mvc;
using MovieRestApi.Core.Utilities.Results;
using MovieRestApi.Models;
using MovieRestApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;
namespace MovieRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAll")]
         public IDataResult<List<Movie>> GetAll()
        {
            return _movieService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Movie>GetById(Guid id)
        {
            return _movieService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(Movie entity)
        {
            return await _movieService.Add(entity);
        }
        [HttpPost("Update")]
        public async Task<IResult> Update(Movie entity)
        {
            return await _movieService.Update(entity);
        }
        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _movieService.Delete(id);
        }
    }
}
