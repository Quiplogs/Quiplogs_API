using Api.Core.Dto;
using Api.Core.Dto.Requests.Service;
using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Service;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Service
{
    public class GetServiceUseCase : IGetServiceUseCase
    {
        private readonly IServiceRepository _repository;

        public GetServiceUseCase(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(GetServiceRequest message, IOutputPort<GetServiceResponse> outputPort)
        {
            var response = await _repository.Get(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new GetServiceResponse(response.Service, true));
                return true;
            }

            outputPort.Handle(new GetServiceResponse(new[] { new Error(GlobalVariables.error_serviceFailure, "Service not Found.") }));
            return false;
        }
    }
}
