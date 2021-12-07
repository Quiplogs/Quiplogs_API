using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.UseCases.Location;
using System.Threading.Tasks;

namespace Api.UseCases.Location.Put
{
    public class LocationController : BaseApiController
    {
        private readonly PutLocationUseCase _putLocationUseCase;
        private readonly PutPresenter<Quiplogs.Core.Domain.Entities.Location> _putPresenter;

        public LocationController(PutLocationUseCase putLocationUseCase, PutPresenter<Quiplogs.Core.Domain.Entities.Location> putPresenter)
        {
            _putLocationUseCase = putLocationUseCase;
            _putPresenter = putPresenter;
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] PutRequest<Quiplogs.Core.Domain.Entities.Location> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            request.Model.CompanyId = GetCompanyId(request.Model.CompanyId);

            await _putLocationUseCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.PutRequest<Quiplogs.Core.Domain.Entities.Location>(request.Model), _putPresenter);
            return _putPresenter.ContentResult;
        }
    }
}