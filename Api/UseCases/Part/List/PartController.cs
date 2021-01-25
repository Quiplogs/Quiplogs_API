using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Quiplogs.Inventory.Interfces.UseCases.Part;

namespace Api.UseCases.Part.List
{
    public class PartController : BaseApiController
    {
        private readonly IListPartUseCase _listPartUseCase;
        private readonly ListPartPresenter _listPartPresenter;

        public PartController(IListPartUseCase listPartUseCase, ListPartPresenter listPartPresenter)
        {
            _listPartUseCase = listPartUseCase;
            _listPartPresenter = listPartPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListPartRequest request)
        {
            if (!ModelState.IsValid)
            { 
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _listPartUseCase.Handle(new Quiplogs.Inventory.Dto.Requests.Part.ListPartRequest(GetCompanyId(request.CompanyId), request.LocationId, request.FilterName, request.PageNumber), _listPartPresenter);
            return _listPartPresenter.ContentResult;
        }
    }
}