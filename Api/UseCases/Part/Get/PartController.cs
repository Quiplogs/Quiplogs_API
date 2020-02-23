﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfaces.UseCases.Part;

namespace Api.UseCases.Part.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IGetPartUseCase _getPartUseCase;
        private readonly GetPartPresenter _getPartPresenter;

        public PartController(IGetPartUseCase getPartUseCase, GetPartPresenter getPartPresenter)
        {
            _getPartUseCase = getPartUseCase;
            _getPartPresenter = getPartPresenter;
        }


        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] GetPartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getPartUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Part.GetPartRequest(request.Id), _getPartPresenter);
            return _getPartPresenter.ContentResult;
        }
    }
}