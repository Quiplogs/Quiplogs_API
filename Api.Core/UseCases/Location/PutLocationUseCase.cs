﻿using System.Threading.Tasks;
using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Location;
using Quiplogs.Core.Dto.Responses.Location;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Location;

namespace Quiplogs.Core.UseCases.Location
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
            //Use automapper
            var location = new Domain.Entities.Location();           

            var existingLocation = await _repository.Get(message.Id);
            if(existingLocation.Location != null)
            {
                location = existingLocation.Location;

                if (!string.IsNullOrEmpty(message.Name))
                    location.Name = message.Name;
                if (!string.IsNullOrEmpty(message.City))
                    location.City = message.City;
                if (!string.IsNullOrEmpty(message.Country))
                    location.Country = message.Country;
                if (!string.IsNullOrEmpty(message.UserId.ToString()))
                    location.UserId = message.UserId;
                if (!string.IsNullOrEmpty(message.Lat))
                    location.Lat = decimal.Parse(message.Lat);
                if (!string.IsNullOrEmpty(message.Long))
                    location.Long = decimal.Parse(message.Long);
            }
            else
            {
                location.Name = message.Name;
                location.City = message.City;
                location.CompanyId = message.CompanyId;
                location.Country = message.Country;                
                location.UserId = message.UserId;

                if (!string.IsNullOrEmpty(message.Lat))
                    location.Lat = decimal.Parse(message.Lat);
                if (!string.IsNullOrEmpty(message.Long))
                    location.Long = decimal.Parse(message.Long);
            }

            var response = await _repository.Put(location);

            //Save Image
            if (!string.IsNullOrEmpty(message.ImageBase64))
            {
                var savedImage = await _blobStorage.UploadImageAsync(new SaveFileRequest
                {
                    Container = message.CompanyId.ToString(),
                    SubContainer = response.Location.Id.ToString(),
                    FileName = message.ImageFileName,
                    FileBase64 = message.ImageBase64,
                    MimeType = message.ImageMimeType
                });

                response.Location.ImgFileName = savedImage.FileName;
                response.Location.ImgUrl = savedImage.FileUrl;

                await _repository.Put(response.Location);
            }

            if (response.Success)
            {
                outputPort.Handle(new PutLocationResponse(response.Location, true));
                return true;
            }

            outputPort.Handle(new PutLocationResponse(new[] { new Error("", "Error updating Location.") }));
            return false;
        }
    }
}
