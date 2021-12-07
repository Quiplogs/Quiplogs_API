using Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.UseCases.BlobStorage;
using System;
using System.Threading.Tasks;

namespace Api.UseCases.BlobStorage.Remove
{
    public class BlobController : BaseApiController
    {
        private readonly RemoveBlobUseCase _useCase;
        private readonly RemovePresenter _presenter;

        public BlobController(RemoveBlobUseCase useCase, RemovePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] Guid foreignKey, string applicationType)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _useCase.Handle(foreignKey, applicationType, _presenter);
            return _presenter.ContentResult;
        }
    }
}