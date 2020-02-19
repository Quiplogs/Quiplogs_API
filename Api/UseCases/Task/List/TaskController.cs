using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Task;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Task.List
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IListTaskUseCase _listTaskUseCase;
        private readonly ListTaskPresenter _listTaskPresenter;

        public TaskController(IListTaskUseCase listTaskUseCase, ListTaskPresenter listTaskPresenter)
        {
            _listTaskUseCase = listTaskUseCase;
            _listTaskPresenter = listTaskPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            await _listTaskUseCase.Handle(new Core.Dto.Requests.Task.ListTaskRequest(request.CompanyId, request.PageNumber), _listTaskPresenter);
            return _listTaskPresenter.ContentResult;
        }
    }
}