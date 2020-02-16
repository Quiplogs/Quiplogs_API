using Api.Core.Interfaces.UseCases.Equipment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.UseCases.Equipment.Fetch
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IFetchEquipmentUseCase _fetchEquipmentUseCase;
        private readonly FetchEquipmentPresenter _fetchEquipmentPresenter;

        public EquipmentController(IFetchEquipmentUseCase fetchEquipmentUseCase, FetchEquipmentPresenter fetchEquipmentPresenter)
        {
            _fetchEquipmentUseCase = fetchEquipmentUseCase;
            _fetchEquipmentPresenter = fetchEquipmentPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromBody] FetchEquipmentRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _fetchEquipmentUseCase.Handle(new Core.Dto.Requests.Equipment.FetchEquipmentRequest(request.CompanyId, request.LocationId, request.PageNumber), _fetchEquipmentPresenter);
            return _fetchEquipmentPresenter.ContentResult;
        }
    }
}