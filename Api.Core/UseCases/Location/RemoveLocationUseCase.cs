using Api.Core.Dto;
using Api.Core.Dto.Requests.Location;
using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Location;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Location
{
    public class RemoveLocationUseCase : IRemoveLocationUseCase
    {
        private readonly ILocationRepository _repository;

        public RemoveLocationUseCase(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveLocationRequest message, IOutputPort<RemoveLocationResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveLocationResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemoveLocationResponse(new[] { new Error("", "Error removing Location.") }));
            return false;
        }
    }
}
