using MovieRestApi.Core.Repository;
using MovieRestApi.Core.Utilities.Results;
using MovieRestApi.Models;
using MovieRestApi.Repository;
using MovieRestApi.Service.Abstract;
using IResult = MovieRestApi.Core.Utilities.Results.IResult;

namespace MovieRestApi.Service.Concrete
{
    public class MovieOperationService : IMovieOperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Movie> _movieRepository;
        private readonly IBaseRepository<Actor> _actorRepository;
        private readonly IBaseRepository<Category> _categoryRepository;
        public MovieOperationService(IUnitOfWork unitOfWork, IBaseRepository<Movie> movieRepository, IBaseRepository<Actor> actorRepository, IBaseRepository<Category> categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> AddActors(Guid id, List<Guid> actorIds)
        {
            var movie = _movieRepository.GetWithNavigation(x => x.Id == id, "Actors");
            if (movie == null)
            {
                return new ErrorResult("Film bulunamadı.");
            }

            var existingActorIds = movie.Actors.Select(a => a.Id).ToList();
            var newActorIds = actorIds.Except(existingActorIds).ToList();

            if (!newActorIds.Any())
            {
                return new ErrorResult("Bu aktörler zaten ekli.");
            }

            var newActors = _actorRepository.GetAll(x => newActorIds.Contains(x.Id)); 

            movie.Actors.AddRange(newActors);

            await _movieRepository.Update(movie); 
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("Yeni aktörler başarıyla eklendi.");
        }

        public async Task<IResult> AddCategories(Guid id, List<Guid> categoryIds)
        {
            var movie = _movieRepository.GetWithNavigation(x=> x.Id == id, "Categories");
            if(movie == null)
            {
                return new ErrorResult("Movie bulunamadı");
            }

            var existingCategoryIds = movie.Categories.Select(a => a.Id).ToList();
            var newCategoryIds = categoryIds.Except(existingCategoryIds).ToList();

            if (!newCategoryIds.Any())
            {
                return new ErrorResult("Bu kategoriler zaten ekli.");
            }

            var newCategories = _categoryRepository.GetAll(x => newCategoryIds.Contains(x.Id));

            movie.Categories.AddRange(newCategories);

            await _movieRepository.Update(movie);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("başarıyla eklendi");
        }
    }
}
