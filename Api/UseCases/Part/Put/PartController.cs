using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Interfces.UseCases.Part;

namespace Api.UseCases.Part.Put
{
    public class PartController : BaseApiController
    {
        private readonly IPutPartUseCase _putPartUseCase;
        private readonly PutPartPresenter _putPartPresenter;

        public PartController(IPutPartUseCase putPartUseCase, PutPartPresenter putPartPresenter)
        {
            _putPartUseCase = putPartUseCase;
            _putPartPresenter = putPartPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutPartRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _putPartUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Part.PutPartRequest(request.Id, request.Code, request.Name, request.Description, GetCompanyId(request.CompanyId), request.LocationId, request.ImageFileName, request.ImageBase64, request.ImageMimeType), _putPartPresenter);
            return _putPartPresenter.ContentResult;
        }
    }
}