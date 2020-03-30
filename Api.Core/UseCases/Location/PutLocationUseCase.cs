using Api.Core.Dto;
using Api.Core.Dto.Requests.Location;
using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Location;
using System.Threading.Tasks;
using Quiplogs.BlobStorage;

namespace Api.Core.UseCases.Location
{
    public class PutLocationUseCase : IPutLocationUseCase
    {
        private readonly ILocationRepository _repository;
        private readonly IBlobStorage _blobStorage;

        public PutLocationUseCase(ILocationRepository repository, IBlobStorage blobStorage)
        {
            _repository = repository;
            _blobStorage = blobStorage;
        }

        public async Task<bool> Handle(PutLocationRequest message, IOutputPort<PutLocationResponse> outputPort)
        {
            var location = new Domain.Entities.Location()
            {
                Name = message.Name,
                City = message.City,
                CompanyId = message.CompanyId,
                Country = message.Country,
                Lat = message.Lat,
                Long = message.Long,
                UserId = message.UserId
            };
            
            var savedLocation = await _repository.Put(location);

            //Save Image
            //var savedImage = await _blobStorage.UploadImageAsync(message.CompanyId, savedLocation.Location.Id, message.ImageFileName, message.ImageBase64, message.ImageMimeType);

            //location.ImgFileName = savedImage.FileName;
            //location.ImgUrl = savedImage.FileUrl;

            var response = await _repository.Put(location);

            if (response.Success)
            {
                outputPort.Handle(new PutLocationResponse(response.Location, true));
                return true;
            }

            outputPort.Handle(new PutLocationResponse(new[] { new Error(GlobalVariables.error_locationFailure, "Error updating Location.") }));
            return false;
        }
    }
}
