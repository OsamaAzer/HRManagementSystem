using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<T> Add(T entity);

        Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);

        T Update(T entity);

        T Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Attach(T entity);

        void AttachRange(IEnumerable<T> entities);

        Task<int> Count(Expression<Func<T, bool>>? criteria);

        Task<IEnumerable<T>> Find(Expression<Func<T,bool>> criteria, string[]? includes = null);

        Task<IEnumerable<T>> Find(string[]? includes = null);

        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> criteria);


        //Task<IEnumerable<T>> GetRange(int skip, int take);

    }
}
