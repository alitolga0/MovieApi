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
        private readonly IBaseRepository<Movie> _baseRepository;
        private readonly IBaseRepository<Actor> _actorRepository;
        public MovieService(IBaseRepository<Movie> baseRepository, IBaseRepository<Actor> actorRepository)
        {
            _baseRepository = baseRepository;
            _actorRepository = actorRepository;
        }

        public async Task<IResult> Add(Movie entity)
        {
            await _baseRepository.Add(entity);
            return new SuccessResult("başarı ile eklendi ");
        }

        public async Task<IResult> AddActors(Guid id, List<Guid> actorIds)
        {
            var movie = _baseRepository.GetWithNavigation(x => x.Id == id, "Actors");
            if (movie == null)
            {
                return new ErrorResult("Film bulunamadı.");
            }

            var existingActorIds = movie.Actors.Select(a => a.Id).ToList(); // Filmdeki mevcut aktörler
            var newActorIds = actorIds.Except(existingActorIds).ToList(); // Yalnızca yeni olanları ekle

            if (!newActorIds.Any())
            {
                return new ErrorResult("Bu aktörler zaten ekli.");
            }

            var newActors = _actorRepository.GetAll(x => newActorIds.Contains(x.Id)); // Sadece yeni aktörleri getir
            foreach (var actor in newActors)
            {
                movie.Actors.Add(actor);
            }

            await _baseRepository.Update(movie); // Güncelleme işlemi
            return new SuccessResult("Yeni aktörler başarıyla eklendi.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
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
            return new SuccessResult("başarı ile güncellendi");
        }
    }
}
