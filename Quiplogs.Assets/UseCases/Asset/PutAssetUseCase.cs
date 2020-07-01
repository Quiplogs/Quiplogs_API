﻿using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using AutoMapper;
using Quiplogs.Assets.Dto.Requests.Asset;
using Quiplogs.Assets.Dto.Responses.Asset;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.Asset;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.Asset
{
    public class PutAssetUseCase : IPutAssetUseCase
    {
        private readonly IAssetRepository _repository;
        private readonly IMapper _mapper;

        public PutAssetUseCase(IAssetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PutAssetRequest message, IOutputPort<PutAssetResponse> outputPort)
        {
            var model = _mapper.Map<Domain.Entities.Asset>(message);

            var response = await _repository.Put(model);
            if (response.Success)
            {
                outputPort.Handle(new PutAssetResponse(response.Asset, true));
                return true;
            }

            outputPort.Handle(new PutAssetResponse(new[] { new Error(GlobalVariables.error_assetFailure, "Error updating Asset.") }));
            return false;
        }
    }
}
