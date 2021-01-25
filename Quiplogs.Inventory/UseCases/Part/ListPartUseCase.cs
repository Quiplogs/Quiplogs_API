﻿using Quiplogs.Inventory.Dto.Requests.Part;
using Quiplogs.Inventory.Dto.Responses.Part;
using System.Threading.Tasks;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Interfaces;
using Quiplogs.Inventory.Interfces.Repositories;
using Quiplogs.Inventory.Interfces.UseCases.Part;

namespace Quiplogs.Inventory.UseCases.Part
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

            var response = await _repository.List(message.CompanyId, message.LocationId, message.FilterName, message.PageNumber, pageSize);
            if (response.Success)
            {
                var total = await _repository.GetTotalRecords(message.CompanyId);
                var pagedResult = new PagedResult<Domain.Entities.Part>(response.Parts, total, message.PageNumber, pageSize);

                outputPort.Handle(new ListPartResponse(pagedResult, true));
                return true;
            }

            outputPort.Handle(new ListPartResponse(new[] { new Error("", "No Parts Found.") }));
            return false;
        }
    }
}
