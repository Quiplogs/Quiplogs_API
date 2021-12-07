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
                    if (!string.IsNullOrWhiteSpace(keyValuePair.Value))
                    {
                        source = source.Where(Filter<T>(keyValuePair.Key, keyValuePair.Value));
                    }
                }
            }

            return source;
        }

        public static IQueryable<T> CustomWhere<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                source = source.Where(predicate);
            }

            return source;
        }

        public static IQueryable<T> CustomOrderBy<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                source = source.OrderBy(predicate);
            }

            return source;
        }

        private static Expression<Func<T, bool>> Filter<T>(string propertyName, string queryText)
        {
            var parameter = Expression.Parameter(typeof(T), "entity");
            var getter = Expression.Property(parameter, propertyName);
            if (getter.Type == typeof(string))
            {
                var stringContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var containsCall = Expression.Call(getter, stringContainsMethod,
                    Expression.Constant(queryText, typeof(string)));
                return Expression.Lambda<Func<T, bool>>(containsCall, parameter);
            }
            if (getter.Type == typeof(int))
            {
                var stringEqualsMethod = typeof(int).GetMethod("Equals", new[] { typeof(int) });
                var equalsCall = Expression.Call(getter, stringEqualsMethod,
                    Expression.Constant(value: Int32.Parse(queryText), typeof(Int32)));
                return Expression.Lambda<Func<T, bool>>(equalsCall, parameter);
            }
            if (getter.Type == typeof(bool))
            {
                var stringEqualsMethod = typeof(bool).GetMethod("Equals", new[] { typeof(bool) });
                var equalsCall = Expression.Call(getter, stringEqualsMethod,
                    Expression.Constant(value: bool.Parse(queryText), typeof(bool)));
                return Expression.Lambda<Func<T, bool>>(equalsCall, parameter);
            }

            throw new Exception("No proper type defined for Filter Parameter. Supports only String, Int and Boolean");
        }
    }
}
