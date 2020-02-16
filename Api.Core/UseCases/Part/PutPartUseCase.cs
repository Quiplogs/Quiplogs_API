using Api.Core.Dto;
using Api.Core.Dto.Requests.Part;
using Api.Core.Dto.Responses.Part;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Part;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Part
{
    public class PutPartUseCase : IPutPartUseCase
    {
        private readonly IPartRepository _repository;

        public PutPartUseCase(IPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutPartRequest message, IOutputPort<PutPartResponse> outputPort)
        {
            var response = await _repository.Put(message.Part);
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
