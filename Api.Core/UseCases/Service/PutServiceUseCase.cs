using Api.Core.Dto;
using Api.Core.Dto.Requests.Service;
using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Service;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Service
{
    public class PutServiceUseCase : IPutServiceUseCase
    {
        private readonly IServiceRepository _repository;

        public PutServiceUseCase(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(PutServiceRequest message, IOutputPort<PutServiceResponse> outputPort)
        {
            var response = await _repository.Put(message.Service);
            if (response.Success)
            {
                outputPort.Handle(new PutServiceResponse(response.Service, true));
                return true;
            }

            outputPort.Handle(new PutServiceResponse(new[] { new Error(GlobalVariables.error_serviceFailure, "Error updating Service.") }));
            return false;
        }
    }
}
