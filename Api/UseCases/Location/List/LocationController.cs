using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Location.List
{
    public class LocationController : BaseApiController
    {
        private readonly IListService<Quiplogs.Core.Domain.Entities.Location, LocationDto> _listService;

        public LocationController(IListService<Quiplogs.Core.Domain.Entities.Location, LocationDto> listService)
        {
            _listService = listService;
        }

        [HttpPost("List")]
        public async Task<ActionResult> PagedList([FromBody] ListRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _listService.List(request, GetCompanyId(request.CompanyId));
            return result;
        }
    }
}
