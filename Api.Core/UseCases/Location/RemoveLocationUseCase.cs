using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;

namespace Quiplogs.Core.UseCases.Location
{
    public class RemoveLocationUseCase : IRemoveUseCase<Domain.Entities.Location, LocationDto>
    {
        private readonly IBaseRepository<Domain.Entities.Location, LocationDto> _baseRepository;
        private readonly IBlobRepository _blobRepository;

        public RemoveLocationUseCase(IBaseRepository<Domain.Entities.Location, LocationDto> baseRepository,
            IBlobRepository blobRepository)
        {
            _baseRepository = baseRepository;
            _blobRepository = blobRepository;
        }

        public async Task<bool> Handle(RemoveRequest request, IOutputPort<RemoveResponse> outputPort)
        {
            try
            {
                await _blobRepository.RemoveBlob(request.Id, "location");
                await _baseRepository.Remove(request.Id);

                outputPort.Handle(new RemoveResponse("Successfully removed Blob", true));
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new RemoveResponse(new Error[] { new Error("BlobException", $"{ex.Message}") }));
                return false;
            }
        }
    }
}
