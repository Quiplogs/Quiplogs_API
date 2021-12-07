using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Data.Entities;

namespace Api.UseCases.Location.PagedList
{
    public class LocationController : BaseApiController
    {
        private readonly IPagedListService<Quiplogs.Core.Domain.Entities.Location, LocationDto> _pagedService;

        public LocationController(IPagedListService<Quiplogs.Core.Domain.Entities.Location, LocationDto> pagedService)
        {
            _pagedService = pagedService;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _pagedService.PagedList(request, GetCompanyId(request.CompanyId));
            return result;
        }
    }
}