using Api.Presenters;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public class RemoveService<T1, T2> : IRemoveService<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IRemoveUseCase<T1, T2> _removeUseCase;
        private readonly RemovePresenter _removePresenter;

        public RemoveService(IRemoveUseCase<T1, T2> removeUseCase, RemovePresenter removePresenter)
        {
            _removeUseCase = removeUseCase;
            _removePresenter = removePresenter;
        }

        public async Task<JsonContentResult> Put(RemoveRequest request)
        {
            await _removeUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.RemoveRequest(request.Id), _removePresenter);
            return _removePresenter.ContentResult;
        }
    }
}
