using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfaces.UseCases.Task;

namespace Api.UseCases.Task.Remove
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IRemoveTaskUseCase _removeTaskUseCase;
        private readonly RemoveTaskPresenter _removeTaskPresenter;

        public TaskController(IRemoveTaskUseCase removeTaskUseCase, RemoveTaskPresenter removeTaskPresenter)
        {
            _removeTaskUseCase = removeTaskUseCase;
            _removeTaskPresenter = removeTaskPresenter;
        }

        [HttpPost("Remove")]
        public async Task<ActionResult> Remove([FromBody] RemoveTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _removeTaskUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Task.RemoveTaskRequest(request.Id), _removeTaskPresenter);
            return _removeTaskPresenter.ContentResult;
        }
    }
}