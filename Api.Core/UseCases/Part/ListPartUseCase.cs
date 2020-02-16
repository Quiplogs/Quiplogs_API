using Api.Core.Domain.Entities;
using Api.Core.Dto;
using Api.Core.Dto.Requests.Part;
using Api.Core.Dto.Responses.Part;
using Api.Core.Interfaces;
using Api.Core.Interfaces.Repositories;
using Api.Core.Interfaces.UseCases.Part;
using System.Threading.Tasks;

namespace Api.Core.UseCases.Part
{
    public class ListPartUseCase : IListPartUseCase
    {
        private readonly IPartRepository _repository;

        public ListPartUseCase(IPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ListPartRequest message, IOutputPort<ListPartResponse> outputPort)
        {
            //temp var
            var pageSize = 20;

            var response = await _repository.List(message.CompanyId, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.Part>(response.Parts, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListPartResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListPartResponse(new[] { new Error(GlobalVariables.error_partFailure, "No Parts Found.") }));
            return false;
        }
    }
}
