using ECommerce.Core.Persistance.Entity;
using ECommerce.Core.Persistance.Options;
using ECommerce.Core.Persistance.PagedList;
using ECommerce.Persistence.Contexts.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace ECommerce.Persistence.Repository
{
    public class Repository<T,TContext>: Core.Persistance.Repository.IRepository<T>
         where T : class, IEntity, new()
         where TContext : DbContext

    {
        readonly private TContext _context;
        private readonly EntityAuditingOptions _entityAuditingOptions = new EntityAuditingOptions();

        public Repository(TContext context)
        {
            _context = context;
        }

        public DbSet<T> DbSet => _context.Set<T>();


        #region Audit

        private void SetDeleteAuditInfoToEntity(T entity)
        {
            if (entity is IDeleteAuditing d)
            {
                d.DeletedDate = DateTime.UtcNow;

                if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                {
                    d.DeletedUser = _entityAuditingOptions.UserId;
                }

                this.SetDeleteAuditInfoToSubEntity(entity, d.DeletedDate, entity.GetType().GetProperties());
            }
        }

        private void SetDeleteAuditInfoToSubEntity(object entity, DateTime? dataTime, PropertyInfo[] properties)
        {
            foreach (PropertyInfo propertyInfo in properties)
            {
                var propertyInfoType = propertyInfo.PropertyType;

                if (propertyInfoType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(propertyInfoType))
                {
                    Type[] genericTypes = null;

                    try
                    {
                        genericTypes = propertyInfoType.GetGenericArguments();
                    }
                    catch (NotSupportedException nse)
                    {
                        genericTypes = new Type[0];
                    }

                    if (!genericTypes.Any())
                    {
                        continue;
                    }

                    Type genericType = genericTypes[0];

                    if (genericType.GetInterfaces().Any(w => w == typeof(IDeleteAuditing)))
                    {
                        var list = (IEnumerable)propertyInfo.GetValue(entity, null);

                        if (list == null)
                        {
                            continue;
                        }

                        foreach (var item in list)
                        {
                            if (item == null)
                            {
                                continue;
                            }

                            if (item is IDeleteAuditing i)
                            {
                                i.DeletedDate = dataTime;

                                if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                                {
                                    i.DeletedUser = _entityAuditingOptions.UserId;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (propertyInfo.PropertyType.GetInterfaces().Any(w => w == typeof(IDeleteAuditing)))
                    {
                        var e2 = (IDeleteAuditing)propertyInfo.GetValue(entity, null);

                        if (e2 == null)
                        {
                            continue;
                        }

                        e2.DeletedDate = dataTime;

                        if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                        {
                            e2.DeletedUser = _entityAuditingOptions.UserId;
                        }
                    }
                }
            }
        }

        private void SetDeleteAuditingInfoToEntityList(IEnumerable<T> entities)
        {
            if (entities.Any() && entities.FirstOrDefault() is IDeleteAuditing)
            {
                foreach (var entity in entities)
                {
                    this.SetDeleteAuditInfoToEntity(entity);
                }
            }
        }

        private void SetInsertAuditInfoToEntity(T entity)
        {
            if (entity is IInsertAuditing e)
            {
                e.InsertedDate = DateTime.UtcNow;

                if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                {
                    e.InsertedUser = _entityAuditingOptions.UserId;
                }

                this.SetInsertAuditInfoToSubEntity(entity, e.InsertedDate, entity.GetType().GetProperties());
            }
        }

        private void SetInsertAuditInfoToSubEntity(object entity, DateTime? dataTime, PropertyInfo[] properties)
        {
            foreach (PropertyInfo propertyInfo in properties)
            {
                var propertyInfoType = propertyInfo.PropertyType;

                if (propertyInfoType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(propertyInfoType))
                {
                    Type[] genericTypes = null;

                    try
                    {
                        genericTypes = propertyInfoType.GetGenericArguments();
                    }
                    catch (NotSupportedException nse)
                    {
                        genericTypes = new Type[0];
                    }

                    if (!genericTypes.Any())
                    {
                        continue;
                    }

                    Type genericType = genericTypes[0];

                    if (genericType.GetInterfaces().Any(w => w == typeof(IInsertAuditing)))
                    {
                        var list = (IEnumerable)propertyInfo.GetValue(entity, null);

                        if (list == null)
                        {
                            continue;
                        }

                        foreach (var item in list)
                        {
                            if (item == null)
                            {
                                continue;
                            }

                            if (item is IInsertAuditing i)
                            {
                                i.InsertedDate = dataTime;

                                if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                                {
                                    i.InsertedUser = _entityAuditingOptions.UserId;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (propertyInfo.PropertyType.GetInterfaces().Any(w => w == typeof(IInsertAuditing)))
                    {
                        var e2 = (IInsertAuditing)propertyInfo.GetValue(entity, null);

                        if (e2 == null)
                        {
                            continue;
                        }

                        e2.InsertedDate = dataTime;

                        if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                        {
                            e2.InsertedUser = _entityAuditingOptions.UserId;
                        }
                    }
                }
            }
        }

        private void SetInsertAuditingInfoToEntityList(IEnumerable<T> entities)
        {
            if (entities.Any() && entities.FirstOrDefault() is IInsertAuditing)
            {
                foreach (var entity in entities)
                {
                    this.SetInsertAuditInfoToEntity(entity);
                }
            }
        }

        private void SetUpdateAuditInfoToEntity(T entity)
        {
            if (entity is IUpdateAuditing e)
            {
                e.UpdatedDate = DateTime.UtcNow;

                if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                {
                    e.UpdatedUser = _entityAuditingOptions.UserId;
                }

                this.SetUpdateAuditInfoToSubEntity(entity, e.UpdatedDate, entity.GetType().GetProperties());
            }
        }

        private void SetUpdateAuditInfoToSubEntity(object entity, DateTime? dataTime, PropertyInfo[] properties)
        {
            foreach (PropertyInfo propertyInfo in properties)
            {
                var propertyInfoType = propertyInfo.PropertyType;

                if (propertyInfoType.IsGenericType && typeof(IEnumerable).IsAssignableFrom(propertyInfoType))
                {
                    Type[] genericTypes = null;

                    try
                    {
                        genericTypes = propertyInfoType.GetGenericArguments();
                    }
                    catch (NotSupportedException nse)
                    {
                        genericTypes = new Type[0];
                    }

                    if (!genericTypes.Any())
                    {
                        continue;
                    }

                    Type genericType = genericTypes[0];

                    if (genericType.GetInterfaces().Any(w => w == typeof(IUpdateAuditing)))
                    {
                        var list = (IEnumerable)propertyInfo.GetValue(entity, null);

                        if (list == null)
                        {
                            continue;
                        }

                        foreach (var item in list)
                        {
                            if (item == null)
                            {
                                continue;
                            }

                            if (item is IUpdateAuditing i)
                            {
                                i.UpdatedDate = dataTime;

                                if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                                {
                                    i.UpdatedUser = _entityAuditingOptions.UserId;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (propertyInfo.PropertyType.GetInterfaces().Any(w => w == typeof(IUpdateAuditing)))
                    {
                        var e2 = (IUpdateAuditing)propertyInfo.GetValue(entity, null);

                        if (e2 == null)
                        {
                            continue;
                        }

                        e2.UpdatedDate = dataTime;

                        if (_entityAuditingOptions != null && !string.IsNullOrEmpty(_entityAuditingOptions.UserId))
                        {
                            e2.UpdatedUser = _entityAuditingOptions.UserId;
                        }
                    }
                }
            }
        }

        private void SetUpdateAuditingInfoToEntityList(IEnumerable<T> entities)
        {
            if (entities.Any() && entities.FirstOrDefault() is IUpdateAuditing)
            {
                foreach (var entity in entities)
                {
                    this.SetUpdateAuditInfoToEntity(entity);
                }
            }
        }

        #endregion Audit

        #region Command
        public virtual void Add(T entity)
        {
            this.SetInsertAuditInfoToEntity(entity);

            DbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual async Task AddAsync(T entity, CancellationToken token = default(CancellationToken))
        {
            this.SetInsertAuditInfoToEntity(entity);

            await DbSet.AddAsync(entity, token).ConfigureAwait(false);

            await _context.SaveChangesAsync(token).ConfigureAwait(false);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
           this.SetInsertAuditingInfoToEntityList(entities);

           DbSet.AddRange(entities);

           _context.SaveChanges();
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken token = default(CancellationToken))
        {
            this.SetInsertAuditingInfoToEntityList(entities);

            await DbSet.AddRangeAsync(entities, token).ConfigureAwait(false);

            await _context.SaveChangesAsync(token).ConfigureAwait(false);
        }

        public virtual void Delete(T entity)
        {
            this.SetDeleteAuditInfoToEntity(entity);

            if (entity is ISoftDelete e)
            {
                e.IsDeleted = true;
               DbSet.Update(entity);
            }
            else
            {
               DbSet.Remove(entity);
            }

            _context.SaveChanges();
        }

        public virtual Task DeleteAsync(T entity, CancellationToken token = default(CancellationToken))
        {
            return Task.Run(() => { this.Delete(entity); }, token);
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {

            this.SetDeleteAuditingInfoToEntityList(entities);

            if (entities.Any() && entities.FirstOrDefault() is ISoftDelete)
            {
                foreach (var entity in entities)
                {
                    if (entity is ISoftDelete e)
                    {
                        e.IsDeleted = true;
                       DbSet.Update(entity);
                    }
                }
            }
            else
            {
               DbSet.RemoveRange(entities);
            }
                _context.SaveChanges();
        }

        public virtual Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken token = default(CancellationToken))
        {
            return Task.Run(() => { this.DeleteRange(entities); }, token);
        }

        public virtual void Update(T entity)
        {
            var state = _context.Entry(entity).State;

            if (state != EntityState.Modified)
            {
                this.SetUpdateAuditInfoToEntity(entity);

               DbSet.Update(entity);
            }

            _context.SaveChanges();
        }

        public virtual Task UpdateAsync(T entity, CancellationToken token = default(CancellationToken))
        {
            return Task.Run(() => { this.Update(entity); }, token);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
          this.SetUpdateAuditingInfoToEntityList(entities);

          DbSet.UpdateRange(entities);
          
          _context.SaveChanges();
        }

        public virtual Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken token = default(CancellationToken))
        {
            return Task.Run(() => { this.UpdateRange(entities); }, token);
        }

        #endregion Command


        #region Query
        public virtual T GetFirstOrDefault(
             Expression<Func<T, bool>> predicate = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
             bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null ? orderBy(query).FirstOrDefault() : query.FirstOrDefault();
        }

        public virtual TResult GetFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? orderBy(query).Select(selector).FirstOrDefault()
                : query.Select(selector).FirstOrDefault();
        }

        public virtual async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? await orderBy(query).FirstOrDefaultAsync()
                : await query.FirstOrDefaultAsync();
        }

        public virtual async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? await orderBy(query).Select(selector).FirstOrDefaultAsync()
                : await query.Select(selector).FirstOrDefaultAsync();
        }

        public virtual List<T> GetList(
               Expression<Func<T, bool>> predicate = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
               bool disableTracking = true)
        {
            return this.GetQueryable(predicate: predicate, orderBy: orderBy, include: include, disableTracking: disableTracking).ToList();
        }

        public virtual List<TResult> GetList<TResult>(
               Expression<Func<T, TResult>> selector,
               Expression<Func<T, bool>> predicate = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
               bool disableTracking = true)
            where TResult : class
        {
            return this.GetQueryable(selector: selector, predicate: predicate, orderBy: orderBy, include: include, disableTracking: disableTracking).ToList();
        }

        public virtual Task<List<T>> GetListAsync(
               Expression<Func<T, bool>> predicate = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
               bool disableTracking = true,
               CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetQueryable(predicate: predicate, orderBy: orderBy, include: include, disableTracking: disableTracking).ToListAsync(cancellationToken);
        }

        public virtual Task<List<TResult>> GetListAsync<TResult>(
               Expression<Func<T, TResult>> selector,
               Expression<Func<T, bool>> predicate = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
               bool disableTracking = true,
               CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class
        {
            return this.GetQueryable(selector: selector, predicate: predicate, orderBy: orderBy, include: include, disableTracking: disableTracking).ToListAsync(cancellationToken);
        }

        public virtual IPagedList<T> GetPagedList(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            int indexFrom = 0,
            bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? orderBy(query).ToPagedList(pageIndex, pageSize, indexFrom)
                : query.ToPagedList(pageIndex, pageSize, indexFrom);
        }

        public virtual IPagedList<TResult> GetPagedList<TResult>(
               Expression<Func<T, TResult>> selector,
               Expression<Func<T, bool>> predicate = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
               int pageIndex = 0,
               int pageSize = 20,
               int indexFrom = 0,
               bool disableTracking = true)
            where TResult : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? orderBy(query).Select(selector).ToPagedList(pageIndex, pageSize, indexFrom)
                : query.Select(selector).ToPagedList(pageIndex, pageSize, indexFrom);
        }

        public virtual Task<IPagedList<T>> GetPagedListAsync(
                       Expression<Func<T, bool>> predicate = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
               int pageIndex = 0,
               int pageSize = 20,
               int indexFrom = 0,
               bool disableTracking = true,
               CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? orderBy(query).ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken)
                : query.ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken);
        }

        public virtual Task<IPagedList<TResult>> GetPagedListAsync<TResult>(
               Expression<Func<T, TResult>> selector,
               Expression<Func<T, bool>> predicate = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
               int pageIndex = 0,
               int pageSize = 20,
               int indexFrom = 0,
               bool disableTracking = true,
               CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null
                ? orderBy(query).Select(selector).ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken)
                : query.Select(selector).ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken);
        }

        public virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<TResult> GetQueryable<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
            where TResult : class
        {
            IQueryable<T> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return orderBy != null ? orderBy(query).Select(selector) : query.Select(selector);
        }
        #endregion

    }
}
