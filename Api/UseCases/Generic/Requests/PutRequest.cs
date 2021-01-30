using Quiplogs.Core.Domain.Entities;

namespace Api.UseCases.Generic.Requests
{
    public class PutRequest<T> where T : BaseEntity
    {
        public T Model { get; set; }
    }
}
