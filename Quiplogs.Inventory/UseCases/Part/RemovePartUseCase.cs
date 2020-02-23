using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Requests.Part;
using Quiplogs.Inventory.Dto.Responses.Part;
using Quiplogs.Inventory.Interfaces.Repositories;
using Quiplogs.Inventory.Interfaces.UseCases.Part;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.UseCases.Part
{
    public class RemovePartUseCase : IRemovePartUseCase
    {
        private readonly IPartRepository _repository;

        public RemovePartUseCase(IPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemovePartRequest message, IOutputPort<RemovePartResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemovePartResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemovePartResponse(new[] { new Error(GlobalVariables.error_partFailure, "Error removing Part.") }));
            return false;
        }
    }
}
