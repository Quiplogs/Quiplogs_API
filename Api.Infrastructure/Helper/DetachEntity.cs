using Api.Infrastructure.SqlContext;
using Microsoft.EntityFrameworkCore;
using Quiplogs.Core.Interfaces;
using System.Linq;

namespace Quiplogs.Infrastructure.Helper
{
    public static class DetachEntity
    {
        public static void DetachLocal<T>(this SqlDbContext context, T t, string entryId) where T : class, IIdentifier
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entryId));
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
