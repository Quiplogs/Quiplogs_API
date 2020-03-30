using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Location;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Location.List
{
    public class LocationController : BaseApiController
    {
        private readonly IListLocationUseCase _listLocationUseCase;
        private readonly ListLocationPresenter _listLocationPresenter;

        public LocationController(IListLocationUseCase listLocationUseCase, ListLocationPresenter listLocationPresenter)
        {
            _listLocationUseCase = listLocationUseCase;
            _listLocationPresenter = listLocationPresenter;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List([FromQuery] ListLocationRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var companyId = request.CompanyId;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = this.GetCompanyId();
            }

            await _listLocationUseCase.Handle(new Core.Dto.Requests.Location.ListLocationRequest(companyId, request.PageNumber), _listLocationPresenter);
            return _listLocationPresenter.ContentResult;
        }
    }
}