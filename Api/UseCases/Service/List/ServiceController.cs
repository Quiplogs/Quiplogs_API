using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Service.List
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IListServiceUseCase _listServiceUseCase;
        private readonly ListServicePresenter _listServicePresenter;

        public ServiceController(IListServiceUseCase listServiceUseCase, ListServicePresenter listServicePresenter)
        {
            _listServiceUseCase = listServiceUseCase;
            _listServicePresenter = listServicePresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListServiceRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _listServiceUseCase.Handle(new Core.Dto.Requests.Service.ListServiceRequest(request.CompanyId, request.LocationId, request.PageNumber), _listServicePresenter);
            return _listServicePresenter.ContentResult;
        }
    }
}