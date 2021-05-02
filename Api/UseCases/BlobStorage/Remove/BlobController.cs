using System.Threading.Tasks;
using Api.Services.Interfaces;
using Api.UseCases.Generic.Requests;
using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;

namespace Api.UseCases.BlobStorage.Remove
{
    public class BlobController : BaseApiController
    {
        private readonly IRemoveService<Blob, BlobEntity> _removeService;

        public BlobController(IRemoveService<Blob, BlobEntity> removeService)
        {
            _removeService = removeService;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] RemoveRequest request)
        {
            if (!ModelState.IsValid)
            {
                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _removeService.Put(request);
            return result;
        }
    }
}