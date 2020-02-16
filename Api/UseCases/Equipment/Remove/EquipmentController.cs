using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Equipment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Equipment.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IRemoveEquipmentUseCase _removeEquipmentUseCase;
        private readonly RemoveEquipmentPresenter _removeEquipmentPresenter;

        public EquipmentController(IRemoveEquipmentUseCase removeEquipmentUseCase, RemoveEquipmentPresenter removeEquipmentPresenter)
        {
            _removeEquipmentUseCase = removeEquipmentUseCase;
            _removeEquipmentPresenter = removeEquipmentPresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemoveEquipmentRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeEquipmentUseCase.Handle(new Core.Dto.Requests.Equipment.RemoveEquipmentRequest(request.Id), _removeEquipmentPresenter);
            return _removeEquipmentPresenter.ContentResult;
        }
    }
}