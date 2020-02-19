using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Task;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Task.Put
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IPutTaskUseCase _putTaskUseCase;
        private readonly PutTaskPresenter _putTaskPresenter;

        public TaskController(IPutTaskUseCase putTaskUseCase, PutTaskPresenter putTaskPresenter)
        {
            _putTaskUseCase = putTaskUseCase;
            _putTaskPresenter = putTaskPresenter;
        }

        [HttpPut("Put")]
        public async Task<ActionResult> Put([FromBody] PutTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _putTaskUseCase.Handle(new Core.Dto.Requests.Task.PutTaskRequest(request.Task), _putTaskPresenter);
            return _putTaskPresenter.ContentResult;
        }
    }
}