using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Requests.Location;
using Api.Core.Dto.Responses.Location;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Location;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Location
{
    public class ListLocationUseCase : IListLocationUseCase
    {
        private readonly ILocationRepository _repository;

        public ListLocationUseCase(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListLocationRequest message, IOutputPort<ListLocationResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.CompanyId, message.PageNumber, message.FilterName, pageSize);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.Location>(response.Locations, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListLocationResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListLocationResponse(new[] { new Error("", "No Locations Found.") }));
            return false;
        }
    }
}
