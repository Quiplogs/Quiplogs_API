using System.Threading.Tasks;
using Api.Presenters;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Interfaces.UseCases.Generic;

namespace Api.Services
{
    public class PutService<T1, T2> : IPutService<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IPutUseCase<T1, T2> _putUseCase;
        private readonly PutPresenter<T1> _putPresenter;

        public PutService(IPutUseCase<T1, T2> putUseCase, PutPresenter<T1> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        public async Task<JsonContentResult> Put(PutRequest<T1> request)
        {
            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<T1>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}
