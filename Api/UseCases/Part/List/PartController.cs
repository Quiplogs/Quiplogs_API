using Api.Core.Interfaces.UseCases.Part;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.UseCases.Part.List
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IListPartUseCase _listPartUseCase;
        private readonly ListPartPresenter _listPartPresenter;

        public PartController(IListPartUseCase listPartUseCase, ListPartPresenter listPartPresenter)
        {
            _listPartUseCase = listPartUseCase;
            _listPartPresenter = listPartPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListPartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _listPartUseCase.Handle(new Core.Dto.Requests.Part.ListPartRequest(request.CompanyId, request.PageNumber), _listPartPresenter);
            return _listPartPresenter.ContentResult;
        }
    }
}