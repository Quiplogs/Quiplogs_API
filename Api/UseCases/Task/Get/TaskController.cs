using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfces.UseCases.Task;

namespace Api.UseCases.Task.Get
{
    public class TaskController : BaseApiController
    {
        private readonly IGetTaskUseCase _getTaskUseCase;
        private readonly GetTaskPresenter _getTaskPresenter;

        public TaskController(IGetTaskUseCase getTaskUseCase, GetTaskPresenter getTaskPresenter)
        {
            _getTaskUseCase = getTaskUseCase;
            _getTaskPresenter = getTaskPresenter;
        }


        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery] GetTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getTaskUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Task.GetTaskRequest(request.Id), _getTaskPresenter);
            return _getTaskPresenter.ContentResult;
        }
    }
}