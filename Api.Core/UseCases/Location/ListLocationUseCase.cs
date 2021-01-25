using System.Threading.Tasks;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.Location;
using Quiplogs.Core.Dto.Responses.Location;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.Location;

namespace Quiplogs.Core.UseCases.Location
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
