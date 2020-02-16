using Api.Core.Dto;
using Api.Core.Dto.Requests.Part;
using Api.Core.Dto.Responses.Part;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Part;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Part
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
