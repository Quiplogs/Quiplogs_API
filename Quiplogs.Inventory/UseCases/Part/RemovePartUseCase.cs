using Quiplogs.BlobStorage;
using Quiplogs.BlobStorage.Models;
using Quiplogs.Core.Data.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Generic;
using Quiplogs.Core.Dto.Responses.Generic;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Generic;
using Quiplogs.Inventory.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.UseCases.Part
{
    public class RemovePartUseCase : IRemoveUseCase<Domain.Entities.Part, PartDto>
    {
        private readonly IBaseRepository<Domain.Entities.Part, PartDto> _baseRepository;
        private readonly IBlobRepository _blobRepository;

        public RemovePartUseCase(IBaseRepository<Domain.Entities.Part, PartDto> baseRepository,
            IBlobRepository blobRepository)
        {
            _baseRepository = baseRepository;
            _blobRepository = blobRepository;
        }

        public async Task<bool> Handle(RemoveRequest request, IOutputPort<RemoveResponse> outputPort)
        {
            try
            {
                await _blobRepository.RemoveBlob(request.Id, "part");
                await _baseRepository.Remove(request.Id);

                outputPort.Handle(new RemoveResponse("Successfully removed Blob", true));
                return true;
            }
            catch (Exception ex)
            {
                outputPort.Handle(new RemoveResponse(new Error[] {new Error("BlobException", $"{ex.Message}")}));
                return false;
            }
        }
    }
}
