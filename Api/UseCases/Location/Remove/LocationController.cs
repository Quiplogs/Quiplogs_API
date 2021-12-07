using Api.Presenters;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.UseCases.Location;
using System.Threading.Tasks;

namespace Api.UseCases.Location.Remove
{
    public class LocationController : BaseApiController
    {
        private readonly RemoveLocationUseCase _useCase;
        private readonly RemovePresenter _presenter;

        public LocationController(RemoveLocationUseCase useCase, RemovePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpDelete]
        public async Task<ActionResult> Put([FromQuery] RemoveRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _useCase.Handle(new Quiplogs.Core.Dto.Requests.Generic.RemoveRequest(request.Id), _presenter);
            return _presenter.ContentResult;
        }
    }
}