

using Restaurantium.DataAccess.Entities;
using System.Linq.Expressions;

namespace Restaurantium.DataAccess.Abstract
{
    public interface IGenericDal<T> where T: class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
