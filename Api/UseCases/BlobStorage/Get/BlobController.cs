using System;
using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.UseCases.BlobStorage;
using System.Threading.Tasks;
using Quiplogs.Core.Dto.Requests.Generic;

namespace Api.UseCases.BlobStorage.Get
{
    public class BlobController : BaseApiController
    {
        private readonly GetBlobUseCase _getUseCase;
        private readonly GetPresenter<Blob> _presenter;

        public BlobController(GetBlobUseCase getUseCase, GetPresenter<Blob> presenter)
        {
            _getUseCase = getUseCase;
            _presenter = presenter;
        }

        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery] Guid foreignKey, string applicationType)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _getUseCase.Handle(foreignKey, applicationType, _presenter);
            return _presenter.ContentResult;
        }
    }
}
