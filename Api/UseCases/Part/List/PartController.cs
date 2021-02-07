using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Inventory.Data.Entities;
using System.Threading.Tasks;

namespace Api.UseCases.Part.List
{
    public class PartController : BaseApiController
    {
        private readonly IListService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> _listService;

        public PartController(IListService<Quiplogs.Inventory.Domain.Entities.Part, PartDto> listService)
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
