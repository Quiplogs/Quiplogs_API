using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Service.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IGetServiceUseCase _getServiceUseCase;
        private readonly GetServicePresenter _getServicePresenter;

        public ServiceController(IGetServiceUseCase getServiceUseCase, GetServicePresenter getServicePresenter)
        {
            _getServiceUseCase = getServiceUseCase;
            _getServicePresenter = getServicePresenter;
        }


        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] GetServiceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getServiceUseCase.Handle(new Core.Dto.Requests.Service.GetServiceRequest(request.Id), _getServicePresenter);
            return _getServicePresenter.ContentResult;
        }
    }
}