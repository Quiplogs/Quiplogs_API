using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using System.Threading.Tasks;
using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;

namespace Quiplogs.Core.UseCases.Generic
{
    public class RemoveUseCase<T1, T2> : IRemoveUseCase<T1, T2>
        where T1 : BaseEntity
        where T2 : BaseEntityDto
    {
        private readonly IBaseRepository<T1, T2> _repository;
        private readonly IBlobStorage _blobStorage;

        public RemoveUseCase(IBaseRepository<T1, T2> repository, IBlobStorage blobStorage)
        {
            _repository = repository;
            _blobStorage = blobStorage;
        }

        public async Task<bool> Handle(RemoveRequest request, IOutputPort<RemoveResponse> outputPort)
        {
            var model = await _repository.GetById(request.Id);

            if (model.Success)
            {
                var imageModel = (IImage) model;
                if (!string.IsNullOrWhiteSpace(imageModel.ImageFileName))
                {
                    var deleteImage = new DeleteFileRequest
                    {
                        Container = imageModel.CompanyId.ToString(),
                        SubContainer = imageModel.Id.ToString(),
                        FileName = imageModel.ImageFileName
                    };

                    await _blobStorage.DeleteBlobImage(deleteImage);
                }
                
                await _repository.Remove(request.Id);

                outputPort.Handle(new RemoveResponse("Removed Successfully", true));
                return true;
            }

            outputPort.Handle(new RemoveResponse(model.Errors));
            return false;
        }
    }
}
