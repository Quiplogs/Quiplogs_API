using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfaces.UseCases.Task;

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

            var companyId = request.CompanyId;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = this.GetCompanyId();
            }

            await _putTaskUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Task.PutTaskRequest(request.Id, request.Name, request.Description, companyId), _putTaskPresenter);
            return _putTaskPresenter.ContentResult;
        }
    }
}