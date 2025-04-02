using MovieRestApi.Core.Repository;
using MovieRestApi.Core.Utilities.Results;
using MovieRestApi.Models;
using MovieRestApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;

namespace MovieRestApi.Service.Concrete
{
    public class DirectorService : IDirectorService
    {
        private readonly IBaseRepository<Director> _baseRepository;
        public DirectorService(IBaseRepository<Director> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IResult> Add(Director entity)
        {
            await _baseRepository.Add(entity);
            return new SuccessResult("Director başarı ile yüklendi");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            return new SuccessResult("Director başarı ile silindi");
        }

        public IDataResult<List<Director>> GetAll(Expression<Func<Director, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult<List<Director>>(data,"Başarı ile listelendi");
        }

        public IDataResult<Director> GetById(Guid id)
        {
            var data = _baseRepository.Get(x=> x.Id == id);
            return new SuccessDataResult<Director>(data,"Başarı ile listelendi");
        }

        public async Task<IResult> Update(Director entity)
        {
            await _baseRepository.Update( entity);
            return new SuccessResult("Başarı ile güncellendi");
        }
    }
}
