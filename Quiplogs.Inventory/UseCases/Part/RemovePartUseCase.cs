using Quiplogs.Inventory.Dto.Requests.Part;
using Quiplogs.Inventory.Dto.Responses.Part;
using System.Threading.Tasks;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;
using Quiplogs.Inventory.Interfces.Repositories;
using Quiplogs.Inventory.Interfces.UseCases.Part;

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

            outputPort.Handle(new RemovePartResponse(new[] { new Error("", "Error removing Part.") }));
            return false;
        }
    }
}
