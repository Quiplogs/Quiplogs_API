using Api.Core.Dto;
using Api.Core.Dto.Requests.Service;
using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Service;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Service
{
    public class RemoveServiceUseCase : IRemoveServiceUseCase
    {
        private readonly IServiceRepository _repository;

        public RemoveServiceUseCase(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveServiceRequest message, IOutputPort<RemoveServiceResponse> outputPort)
        {
            var response = await _repository.Remove(message.Id);
            if (response.Success)
            {
                outputPort.Handle(new RemoveServiceResponse(response.Description, true));
                return true;
            }

            outputPort.Handle(new RemoveServiceResponse(new[] { new Error(GlobalVariables.error_serviceFailure, "Error removing Service.") }));
            return false;
        }
    }
}
