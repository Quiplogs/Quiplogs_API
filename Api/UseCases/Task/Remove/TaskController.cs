using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfces.UseCases.Task;

namespace Api.UseCases.Task.Remove
{
    public class TaskController : BaseApiController
    {
        private readonly IRemoveTaskUseCase _removeTaskUseCase;
        private readonly RemoveTaskPresenter _removeTaskPresenter;

        public TaskController(IRemoveTaskUseCase removeTaskUseCase, RemoveTaskPresenter removeTaskPresenter)
        {
            _removeTaskUseCase = removeTaskUseCase;
            _removeTaskPresenter = removeTaskPresenter;
        }

        [HttpDelete()]
        public async Task<ActionResult> Remove([FromQuery] RemoveTaskRequest request)
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