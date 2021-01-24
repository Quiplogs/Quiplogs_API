using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfaces.UseCases.Task;

namespace Api.UseCases.Task.List
{
    public class TaskController : BaseApiController
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

            await _listTaskUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Task.ListTaskRequest(GetCompanyId(request.CompanyId), request.PageNumber, request.FilterName), _listTaskPresenter);
            return _listTaskPresenter.ContentResult;
        }
    }
}