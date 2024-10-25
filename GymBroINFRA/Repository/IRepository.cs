using System.Linq.Expressions;

namespace GymBroINFRA.Repository
{
    public interface IRepository<T> where T : class
    {

        T Create(T item);

        Task<T> CreateAsync(T entity);
        T FindByID(long id);

        List<T> FindAll();
        Task<IEnumerable<T>> GetAllAsync();

        T Update(T item);
        

        void Delete(long id);

        Task<T> FindByEmail(string email);

        IQueryable<T> Where(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
    }
}
