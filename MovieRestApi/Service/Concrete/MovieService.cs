using MovieRestApi.Core.Repository;
using MovieRestApi.Core.Utilities.Results;
using MovieRestApi.Models;
using MovieRestApi.Service.Abstract;
using System.Linq.Expressions;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;
namespace MovieRestApi.Service.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Movie> _baseRepository;
        public MovieService(IBaseRepository<Movie> baseRepository, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Movie entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarı ile eklendi ");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarı ile silindi");
        }

        public IDataResult<List<Movie>> GetAll(Expression<Func<Movie, bool>> filter = null)
        {
            var data = _baseRepository.GetAllWithNavigation(filter, "Director", "Categories", "Actors");
            return new SuccessDataResult<List<Movie>>(data,"başarı ile listelendi");
        }

        public IDataResult<Movie> GetById(Guid id)
        {
            var data = _baseRepository.Get(x => x.Id == id);
            return new SuccessDataResult<Movie>(data,"başarı ile listelendi");
        }

        public async Task<IResult> Update(Movie entity)
        {
            await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarı ile güncellendi");
        }
    }
}
