using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Inventory.Dto.Requests.Part;
using Quiplogs.Inventory.Dto.Responses.Part;
using Quiplogs.Inventory.Interfaces.Repositories;
using Quiplogs.Inventory.Interfaces.UseCases.Part;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.UseCases.Part
{
    public class PutPartUseCase : IPutPartUseCase
    {
        private readonly IPartRepository _repository;
        private readonly IBlobStorage _blobStorage;

        public PutPartUseCase(IPartRepository repository, IBlobStorage blobStorage)
        {
            _repository = repository;
            _blobStorage = blobStorage;
        }

        public async Task<bool> Handle(PutPartRequest message, IOutputPort<PutPartResponse> outputPort)
        {
            //Use automapper
            var model = new Domain.Entities.Part();

            var existingModel= await _repository.Get(message.Id);
            if (existingModel.Part != null)
            {
                model = existingModel.Part;

                if (!string.IsNullOrEmpty(message.Code))
                    model.Code = message.Code;
                if (!string.IsNullOrEmpty(message.Name))
                    model.Name = message.Name;
                if (!string.IsNullOrEmpty(message.Description))
                    model.Description = message.Description;
                if (!string.IsNullOrEmpty(message.CompanyId))
                    model.CompanyId = message.CompanyId;
                if (!string.IsNullOrEmpty(message.LocationId))
                    model.LocationId = message.LocationId;
            }
            else
            {
                model.Code = message.Code;
                model.Name = message.Name;
                model.CompanyId = message.CompanyId;
                model.Description = message.Description;
                model.LocationId = message.LocationId;
            }

            var response = await _repository.Put(model);

            //Save Image
            if (!string.IsNullOrEmpty(message.ImageBase64))
            {
                var savedImage = await _blobStorage.UploadImageAsync(new SaveFileRequest
                {
                    Container = message.CompanyId,
                    SubContainer = response.Part.Id,
                    FileName = message.ImageFileName,
                    FileBase64 = message.ImageBase64,
                    MimeType = message.ImageMimeType
                });

                response.Part.ImgFileName = savedImage.FileName;
                response.Part.ImgUrl = savedImage.FileUrl;

                await _repository.Put(response.Part);
            }

            if (response.Success)
            {
                outputPort.Handle(new PutPartResponse(response.Part, true));
                return true;
            }

            outputPort.Handle(new PutPartResponse(new[] { new Error(GlobalVariables.error_partFailure, "Error updating Part.") }));
            return false;
        }
    }
}
