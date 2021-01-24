using System.Threading.Tasks;
using Api.Core.Domain.Entities;
using Api.Presenters;
using Api.UseCases.Generic.Get;
using Quiplogs.Core.Data.Entities;

namespace Api.Services.Interfaces
{
    public interface IGetService<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        Task<JsonContentResult> Get(GetRequest request);
    }
}
