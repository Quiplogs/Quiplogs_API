using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfces.UseCases.Task;

namespace Api.UseCases.Task.Put
{
    public class TaskController : BaseApiController
    {
        private readonly IPutTaskUseCase _putTaskUseCase;
        private readonly PutTaskPresenter _putTaskPresenter;

        public TaskController(IPutTaskUseCase putTaskUseCase, PutTaskPresenter putTaskPresenter)
        {
            _putTaskUseCase = putTaskUseCase;
            _putTaskPresenter = putTaskPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutTaskRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            if(request == null)
            {
                return BadRequest();
            }

            await _putTaskUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Task.PutTaskRequest(request.Id, request.Name, request.Description, GetCompanyId(request.CompanyId)), _putTaskPresenter);
            return _putTaskPresenter.ContentResult;
        }
    }
}