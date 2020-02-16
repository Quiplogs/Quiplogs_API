using Api.Core.Dto;
using Api.Core.Dto.Requests.Location;
using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories.Location;
using Api.Core.Interfaces.UseCases.Location;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Location
{
    public class PutLocationUseCase : IPutLocationUseCase
    {
        private readonly ILocationRepository _repository;

        public PutLocationUseCase(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutLocationRequest message, IOutputPort<PutLocationResponse> outputPort)
        {
            var response = await _repository.Put(message.Location);
            if (response.Success)
            {
                outputPort.Handle(new PutLocationResponse(response.Location, true));
                return true;
            }

            outputPort.Handle(new PutLocationResponse(new[] { new Error(GlobalVariables.error_locationFailure, "Error updating Location.") }));
            return false;
        }
    }
}
