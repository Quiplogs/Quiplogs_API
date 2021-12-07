using System;
using System.Threading.Tasks;
using Quiplogs.Core.Domain.Entities;

namespace Quiplogs.Core.Interfaces.Repositories
{
    public interface IBlobRepository
    {
        Task<Blob> Get(Guid foreignKeyId, string applicationType);
        public Task RemoveBlobImage(Guid foreignKeyId, string applicationType);
        public Task PersistBlob(Blob blob);
    }
}
