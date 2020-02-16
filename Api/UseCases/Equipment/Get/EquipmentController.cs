using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Equipment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Equipment.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IGetEquipmentUseCase _getEquipmentUseCase;
        private readonly GetEquipmentPresenter _getEquipmentPresenter;

        public EquipmentController(IGetEquipmentUseCase getEquipmentUseCase, GetEquipmentPresenter getEquipmentPresenter)
        {
            _getEquipmentUseCase = getEquipmentUseCase;
            _getEquipmentPresenter = getEquipmentPresenter;
        }


        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] GetEquipmentRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getEquipmentUseCase.Handle(new Core.Dto.Requests.Equipment.GetEquipmentRequest(request.Id), _getEquipmentPresenter);
            return _getEquipmentPresenter.ContentResult;
        }
    }
}