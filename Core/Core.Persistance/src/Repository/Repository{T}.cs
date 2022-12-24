
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistance
{
    public interface IRepository<T>
        where T : class, new()
    {
        T GetFirstOrDefault(
           Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
           bool disableTracking = true);

        TResult GetFirstOrDefault<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        List<T> GetList(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        List<TResult> GetList<TResult>(
             Expression<Func<T, TResult>> selector,
             Expression<Func<T, bool>> predicate = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
             bool disableTracking = true)
            where TResult : class;

        Task<List<T>> GetListAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<TResult>> GetListAsync<TResult>(
              Expression<Func<T, TResult>> selector,
              Expression<Func<T, bool>> predicate = null,
              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
              Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
              bool disableTracking = true,
              CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class;

        IPagedList<T> GetPagedList(
          Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          int pageIndex = 0,
          int pageSize = 20,
          int indexFrom = 0,
          bool disableTracking = true);

        IPagedList<TResult> GetPagedList<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            int indexFrom = 0,
            bool disableTracking = true)
            where TResult : class;

        Task<IPagedList<T>> GetPagedListAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            int indexFrom = 0,
            bool disableTracking = true,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IPagedList<TResult>> GetPagedListAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            int indexFrom = 0,
            bool disableTracking = true,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class;

        IQueryable<T> GetQueryable(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);

        IQueryable<TResult> GetQueryable<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true)
            where TResult : class;


        void Add(T entity);

        Task AddAsync(T entity, CancellationToken token = default(CancellationToken));

        void AddRange(IEnumerable<T> entities);

        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken token = default(CancellationToken));

        void Delete(T entity);

        Task DeleteAsync(T entity, CancellationToken token = default(CancellationToken));

        void DeleteRange(IEnumerable<T> entities);

        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken token = default(CancellationToken));

        //(IDataContext dataContext, bool isUow, IQueryable<T> dbSet) GetDbSetByQuery(bool disableTracking = false);

        void Update(T entity);

        Task UpdateAsync(T entity, CancellationToken token = default(CancellationToken));

        void UpdateRange(IEnumerable<T> entities);

        Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken token = default(CancellationToken));

    }
}
