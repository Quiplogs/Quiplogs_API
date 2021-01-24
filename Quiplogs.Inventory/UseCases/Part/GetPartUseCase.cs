using Api.Core.Dto;
using Api.Core.Interfaces;
using Quiplogs.Inventory.Dto.Requests.Part;
using Quiplogs.Inventory.Dto.Responses.Part;
using Quiplogs.Inventory.Interfaces.Repositories;
using Quiplogs.Inventory.Interfaces.UseCases.Part;
using System.Threading.Tasks;

namespace Quiplogs.Inventory.UseCases.Part
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

            outputPort.Handle(new GetPartResponse(new[] { new Error("", "Part not Found.") }));
            return false;
        }
    }
}
