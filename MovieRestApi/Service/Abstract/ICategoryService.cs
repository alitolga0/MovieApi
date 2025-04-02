using MovieRestApi.Core.Service;
using MovieRestApi.Models;

namespace MovieRestApi.Service.Abstract
{
    public interface ICategoryService : IBaseService<Category,Guid>
    {
    }
}
