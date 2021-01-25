using System.Threading.Tasks;
using Api.Presenters;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Get;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces.UseCases.Generic;

namespace Api.Services
{
    public class GetService<T1, T2> : IGetService<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IGetUseCase<T1, T2> _getUseCase;
        private readonly GetPresenter<T1> _getPresenter;

        public GetService(IGetUseCase<T1, T2> getUseCase, GetPresenter<T1> getPresenter)
        {
            _getUseCase = getUseCase;
            _getPresenter = getPresenter;
        }

        public async Task<JsonContentResult> Get(GetRequest request)
        {

            await _getUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.GetRequest<T1>(request.Id), _getPresenter);
            return _getPresenter.ContentResult;
        }
    }
}
