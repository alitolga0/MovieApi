using Microsoft.AspNetCore.Mvc;
using MovieRestApi.Core.Utilities.Results;
using MovieRestApi.Models;
using MovieRestApi.Service.Abstract;
using MovieRestApi.Service.Concrete;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;
namespace MovieRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Director>> GetAll()
        {
            return _directorService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Director> GetById(Guid id)
        {
            return _directorService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(Director entity)
        {
            return await _directorService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(Director entity)
        {
            return await _directorService.Update(entity);
        }
        [HttpPost("Delete")]

        public async Task<IResult> Delete(Guid id)
        {
            return await _directorService.Delete(id);
        }
    }
}
