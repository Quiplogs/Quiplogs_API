using System.Threading.Tasks;
using Api.Core.Interfaces.UseCases.Location;
using Microsoft.AspNetCore.Mvc;

namespace Api.UseCases.Location.Put
{
    public class LocationController : BaseApiController
    {
        private readonly IPutLocationUseCase _putLocationUseCase;
        private readonly PutLocationPresenter _putLocationPresenter;

        public LocationController(IPutLocationUseCase putLocationUseCase, PutLocationPresenter putLocationPresenter)
        {
            _putLocationUseCase = putLocationUseCase;
            _putLocationPresenter = putLocationPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutLocationRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _putLocationUseCase.Handle(new Core.Dto.Requests.Location.PutLocationRequest(request.Id, request.Name, request.City, request.Country, request.UserId, GetCompanyId(request.CompanyId), request.ImageFileName, request.ImageBase64, request.ImageMimeType, request.Lat.ToString(), request.Long.ToString()), _putLocationPresenter);
            return _putLocationPresenter.ContentResult;
        }
    }
}