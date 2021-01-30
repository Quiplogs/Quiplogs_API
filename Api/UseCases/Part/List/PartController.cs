using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Quiplogs.Inventory.Data.Entities;

namespace Api.UseCases.Part.List
{
    public class PartController : BaseApiController
    {
        private readonly IPagedListService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> _pagedService;

        public PartController(IPagedListService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> pagedService)
        {
            _pagedService = pagedService;
        }

        [HttpPost("PagedList")]
        public async Task<ActionResult> PagedList([FromBody] PagedListRequest<Quiplogs.Inventory.Domain.Entities.Part> request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _pagedService.PagedList(request);
            return result;
        }
    }
}