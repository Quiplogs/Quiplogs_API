using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.UseCases.Part;
using System.Threading.Tasks;

namespace Api.UseCases.Part.Put
{
    public class PartController : BaseApiController
    {
        private readonly PutPartUseCase _putUseCase;
        private readonly PutPresenter<Quiplogs.Inventory.Domain.Entities.Part> _putPresenter;

        public PartController(PutPartUseCase putUseCase, PutPresenter<Quiplogs.Inventory.Domain.Entities.Part> putPresenter)
        {
            _putUseCase = putUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.Inventory.Domain.Entities.Part> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<Quiplogs.Inventory.Domain.Entities.Part>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}