﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfaces.UseCases.Part;

namespace Api.UseCases.Part.Remove
{
    public class PartController : BaseApiController
    {
        private readonly IRemovePartUseCase _removePartUseCase;
        private readonly RemovePartPresenter _removePartPresenter;

        public PartController(IRemovePartUseCase removePartUseCase, RemovePartPresenter removePartPresenter)
        {
            _removePartUseCase = removePartUseCase;
            _removePartPresenter = removePartPresenter;
        }

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromQuery] RemovePartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removePartUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Part.RemovePartRequest(request.Id), _removePartPresenter);
            return _removePartPresenter.ContentResult;
        }
    }
}