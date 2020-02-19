using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Task;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Task.Get
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IGetTaskUseCase _getTaskUseCase;
        private readonly GetTaskPresenter _getTaskPresenter;

        public TaskController(IGetTaskUseCase getTaskUseCase, GetTaskPresenter getTaskPresenter)
        {
            _getTaskUseCase = getTaskUseCase;
            _getTaskPresenter = getTaskPresenter;
        }


        [HttpGet("Get")]
        public async Task<ActionResult> Get([FromQuery] GetTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _getTaskUseCase.Handle(new Core.Dto.Requests.Task.GetTaskRequest(request.Id), _getTaskPresenter);
            return _getTaskPresenter.ContentResult;
        }
    }
}