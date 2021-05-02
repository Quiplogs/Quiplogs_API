using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.UseCases.BlobStorage;
using System.Threading.Tasks;

namespace Api.UseCases.BlobStorage.Put
{
    public class BlobController : BaseApiController
    {
        private readonly PutBlobUseCase _putUseCase;
        private readonly PutPresenter<Quiplogs.Core.Domain.Entities.Blob> _putPresenter;

        public BlobController(PutBlobUseCase putUseCase, PutPresenter<Quiplogs.Core.Domain.Entities.Blob> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.Core.Domain.Entities.Blob> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<Quiplogs.Core.Domain.Entities.Blob>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}
