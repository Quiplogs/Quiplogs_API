using Microsoft.AspNetCore.Mvc;
using Quiplogs.Core.Interfaces.UseCases.FileRemove;
using System.Threading.Tasks;

namespace Api.UseCases.BlobStorage.RemoveFile
{
    public class BlobController : BaseApiController
    {
        private readonly IRemoveFileUseCase _removeFileUseCase;
        private readonly RemoveFilePresenter _removeFilePresenter;

        public BlobController(IRemoveFileUseCase removeFileUseCase, RemoveFilePresenter removeFilePresenter)
        {
            _removeFileUseCase = removeFileUseCase;
            _removeFilePresenter = removeFilePresenter;
        }

        [HttpDelete("Image")]
        public async Task<ActionResult> Image([FromQuery] RemoveFileRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _removeFileUseCase.Handle(new Quiplogs.Core.Dto.Requests.BlobStorage.RemoveFileRequest(request.FileName, request.ApplicationType), _removeFilePresenter);
            return _removeFilePresenter.ContentResult;
        }
    }
}