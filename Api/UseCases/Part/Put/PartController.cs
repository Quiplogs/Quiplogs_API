using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfaces.UseCases.Part;

namespace Api.UseCases.Part.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IPutPartUseCase _putPartUseCase;
        private readonly PutPartPresenter _putPartPresenter;

        public PartController(IPutPartUseCase putPartUseCase, PutPartPresenter putPartPresenter)
        {
            _putPartUseCase = putPartUseCase;
            _putPartPresenter = putPartPresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutPartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putPartUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Part.PutPartRequest(request.Part), _putPartPresenter);
            return _putPartPresenter.ContentResult;
        }
    }
}