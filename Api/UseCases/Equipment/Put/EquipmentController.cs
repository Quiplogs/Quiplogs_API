using Api.Core.Interfaces.UseCases.Equipment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.UseCases.Equipment.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IPutEquipmentUseCase _putEquipmentUseCase;
        private readonly PutEquipmentPresenter _putEquipmentPresenter;

        public EquipmentController(IPutEquipmentUseCase putEquipmentUseCase, PutEquipmentPresenter putEquipmentPresenter)
        {
            _putEquipmentUseCase = putEquipmentUseCase;
            _putEquipmentPresenter = putEquipmentPresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutEquipmentRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putEquipmentUseCase.Handle(new Core.Dto.Requests.Equipment.PutEquipmentRequest(request.Equipment), _putEquipmentPresenter);
            return _putEquipmentPresenter.ContentResult;
        }
    }
}