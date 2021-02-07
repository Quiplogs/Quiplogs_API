using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Quiplogs.Infrastructure.Helper
{
    public static class QueryBuilder
    {
        public static IQueryable<T> CustomWhere<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                source.Where(predicate);
            }

            return source;
        }

        public static IQueryable<T> CustomInclude<T>(this IQueryable<T> source, params Expression<Func<T, object>>[] including)
        {
            including?.ToList().ForEach(include =>
            {
                if (include != null)
                    source = source.Include(include);
            });

            return source;
        }

        public static IQueryable<T> FilterByString<T>(this IQueryable<T> source, Dictionary<string, string> filterParameters = null)
        {
            if (filterParameters != null)
            {
                foreach (var keyValuePair in filterParameters)
                {
                    source.Where(Like<T>(keyValuePair.Key, keyValuePair.Value));
                }
            }

            return source;
        }

        private static Expression<Func<T, bool>> Like<T>(string propertyName, string queryText)
        {
            var parameter = Expression.Parameter(typeof(T), "entity");
            var getter = Expression.Property(parameter, propertyName);
            if (getter.Type != typeof(string))
                throw new ArgumentException("Property must be a string");
            var stringContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var containsCall = Expression.Call(getter, stringContainsMethod,
                Expression.Constant(queryText, typeof(string)));
            return Expression.Lambda<Func<T, bool>>(containsCall, parameter);
        }
    }
}
