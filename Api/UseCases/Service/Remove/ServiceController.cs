using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Service.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IRemoveServiceUseCase _removeServiceUseCase;
        private readonly RemoveServicePresenter _removeServicePresenter;

        public ServiceController(IRemoveServiceUseCase removeServiceUseCase, RemoveServicePresenter removeServicePresenter)
        {
            _removeServiceUseCase = removeServiceUseCase;
            _removeServicePresenter = removeServicePresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemoveServiceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeServiceUseCase.Handle(new Core.Dto.Requests.Service.RemoveServiceRequest(request.Id), _removeServicePresenter);
            return _removeServicePresenter.ContentResult;
        }
    }
}