using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Service.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IPutServiceUseCase _putServiceUseCase;
        private readonly PutServicePresenter _putServicePresenter;

        public ServiceController(IPutServiceUseCase putServiceUseCase, PutServicePresenter putServicePresenter)
        {
            _putServiceUseCase = putServiceUseCase;
            _putServicePresenter = putServicePresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutServiceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putServiceUseCase.Handle(new Core.Dto.Requests.Service.PutServiceRequest(request.Service), _putServicePresenter);
            return _putServicePresenter.ContentResult;
        }
    }
}