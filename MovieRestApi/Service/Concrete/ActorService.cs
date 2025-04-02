using MovieRestApi.Core.Repository;
using MovieRestApi.Core.Utilities.Results;
using MovieRestApi.Models;
using MovieRestApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;

namespace MovieRestApi.Service.Concrete
{
    public class ActorService : IActorService
    {
        private readonly IBaseRepository<Actor> _baseRepository;

        public ActorService(IBaseRepository<Actor> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IResult> Add(Actor entity)
        {
            await _baseRepository.Add(entity);
            return new SuccessResult("Actor başarı ile kaydedildi");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            return new SuccessResult("Actor başarı ile silindi");
        }

        public IDataResult<List<Actor>> GetAll(Expression<Func<Actor, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult< List<Actor>>(data,"Actorler Başarı ile listelendi");
        }

        public IDataResult<Actor> GetById(Guid id)
        {
            var data = _baseRepository.Get(x => x.Id == id);
            return new SuccessDataResult<Actor>(data, "Actor listelendi");
        }

        public async Task<IResult> Update(Actor entity)
        {
            await _baseRepository.Update(entity);
            return new SuccessResult("Actor Güncellendi");
        }
    }
}
