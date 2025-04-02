using MovieRestApi.Core.Repository;
using MovieRestApi.Core.Utilities.Results;
using MovieRestApi.Models;
using MovieRestApi.Service.Abstract;
using System.Linq.Expressions;
using IResult= MovieRestApi.Core.Utilities.Results.IResult;
namespace MovieRestApi.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Category> _baseRepository;

        public CategoryService(IBaseRepository<Category> baseRepository, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Category entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("kategori başarı ile kaydedildi");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("kategori başarı ile silindi");
        }

        public IDataResult<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult<List<Category>>(data, " kategori başarı ile listelendi");
        }

        public IDataResult<Category> GetById(Guid id)
        {
            var data = _baseRepository.Get(x=> x.Id == id);
            return new SuccessDataResult<Category>(data, " kategori başarı ile listelendi");
        }

        public async Task<IResult> Update(Category entity)
        {
            await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarı ile güncellendi");
        }
    }
}
