
using System.Linq.Expressions;
using System.Reflection;

namespace Ecommerce.Core.Common.Extensions
{
    /// <summary>
    /// IOrdered Queryable Extensions.
    /// </summary>
    public static class OrderedQueryableExtensions
    {
        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>IOrderedQueryable{TSource}.</returns>
        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);
            var propertyInfo = entityType.GetProperties().First(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            var selector = GetOrderSelector(entityType, propertyInfo);
            var orderMethod = GetOrderMethod(entityType, propertyInfo, true);
            var newQuery = (IOrderedQueryable<TSource>)orderMethod.Invoke(orderMethod, new object[] { query, selector });
            return newQuery;
        }

        /// <summary>
        /// Orders the by descending.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>IOrderedQueryable{TSource}.</returns>
        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);
            var propertyInfo = entityType.GetProperties().First(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            var selector = GetOrderSelector(entityType, propertyInfo);
            var orderMethod = GetOrderMethod(entityType, propertyInfo, false);
            var newQuery = (IOrderedQueryable<TSource>)orderMethod.Invoke(orderMethod, new object[] { query, selector });
            return newQuery;
        }

        /// <summary>
        /// Gets the order method.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="orderDirectionAsc">if set to <c>true</c> [order direction asc].</param>
        /// <returns>MethodInfo.</returns>
        private static MethodInfo GetOrderMethod(Type entityType, PropertyInfo propertyInfo, bool orderDirectionAsc)
        {
            var enumerableType = typeof(System.Linq.Queryable);

            var orderBy = orderDirectionAsc ? "OrderBy" : "OrderByDescending";

            var method = enumerableType.GetMethods()
                .Where(m => m.Name == orderBy && m.IsGenericMethodDefinition)
                .Single(m =>
                {
                    var parameters = m.GetParameters().ToList();
                    return parameters.Count == 2;
                });

            MethodInfo genericMethod = method.MakeGenericMethod(entityType, propertyInfo.PropertyType);

            return genericMethod;
        }

        /// <summary>
        /// Gets the order selector.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="propertyInfo">The property information.</param>
        /// <returns>LambdaExpression.</returns>
        private static LambdaExpression GetOrderSelector(Type entityType, PropertyInfo propertyInfo)
        {
            var arg = Expression.Parameter(entityType, "x");
            var property = Expression.Property(arg, propertyInfo.Name);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });
            return selector;
        }
    }
}
