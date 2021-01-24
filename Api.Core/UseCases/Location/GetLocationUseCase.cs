using Api.Core.Dto;
using Api.Core.Dto.Requests.Location;
using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Location;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Location
{
    public class GetLocationUseCase : IGetLocationUseCase
    {
        private readonly ILocationRepository _repository;

        public GetLocationUseCase(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetLocationRequest message, IOutputPort<GetLocationResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetLocationResponse(response.Location, true));
                return true;
            }

            outputPort.Handle(new GetLocationResponse(new[] { new Error("", "Location not Found.") }));
            return false;
        }
    }
}
