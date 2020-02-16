using Api.Core.Dto;
using Api.Core.Dto.Requests.Part;
using Api.Core.Dto.Responses.Part;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Part;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Part
{
    public class GetPartUseCase : IGetPartUseCase
    {
        private readonly IPartRepository _repository;

        public GetPartUseCase(IPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetPartRequest message, IOutputPort<GetPartResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetPartResponse(response.Part, true));
                return true;
            }

            outputPort.Handle(new GetPartResponse(new[] { new Error(GlobalVariables.error_partFailure, "Part not Found.") }));
            return false;
        }
    }
}
