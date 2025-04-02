using Microsoft.AspNetCore.Mvc;
using MovieRestApi.Core.Utilities.Results;
using MovieRestApi.Models;
using MovieRestApi.Service.Abstract;
using MovieRestApi.Service.Concrete;
using System.Linq.Expressions;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;
namespace MovieRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Actor>> GetAll()
        {
            return _actorService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Actor> GetById(Guid id) 
        {
            return _actorService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(Actor entity)
        {
            return await _actorService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(Actor entity)
        {
            return await _actorService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _actorService.Delete(id);
        }
    }
}
