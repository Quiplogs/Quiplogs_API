using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Quiplogs.Infrastructure.Helper
{
    public static class QueryBuilder
    {
        public static IQueryable<T> CustomInclude<T>(this IQueryable<T> source, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            if (include != null)
            {
                source = include(source);
            }

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
