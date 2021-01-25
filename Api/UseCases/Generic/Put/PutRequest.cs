using Quiplogs.Core.Domain.Entities;

namespace Api.UseCases.Generic.Put
{
    public class PutRequest<T> where T : BaseEntity
    {
        public T Model { get; set; }
    }
}
