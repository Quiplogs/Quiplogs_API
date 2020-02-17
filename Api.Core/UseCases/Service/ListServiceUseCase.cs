using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Requests.Service;
using Api.Core.Dto.Responses.Service;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Service;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Service
{
    public class ListServiceUseCase : IListServiceUseCase
    {
        private readonly IServiceRepository _repository;

        public ListServiceUseCase(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListServiceRequest message, IOutputPort<ListServiceResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.CompanyId, message.LocationId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.Service>(response.Services, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListServiceResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListServiceResponse(new[] { new Error(GlobalVariables.error_serviceFailure, "No Services Found.") }));
            return false;
        }
    }
}
