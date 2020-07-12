using Api.Core;
using Api.Core.Dto;
using Api.Core.Interfaces;
using AutoMapper;
using Quiplogs.Assets.Dto.Requests.AssetUsage;
using Quiplogs.Assets.Dto.Responses.AssetUsage;
using Quiplogs.Assets.Interfaces.Repositories;
using Quiplogs.Assets.Interfaces.UseCases.AssetUsage;
using System.Threading.Tasks;

namespace Quiplogs.Assets.UseCases.AssetUsage
{
    public class PutAssetUsageUseCase : IPutAssetUsageUseCase
    {
        private readonly IAssetUsageRepository _repository;
        private readonly IMapper _mapper;

        public PutAssetUsageUseCase(IAssetUsageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(PutAssetUsageRequest message, IOutputPort<PutAssetUsageResponse> outputPort)
        {
            var model = _mapper.Map<Domain.Entities.AssetUsage>(message);

            var response = await _repository.Put(model);
            if (response.Success)
            {
                outputPort.Handle(new PutAssetUsageResponse(response.AssetUsage, true));
                return true;
            }

            outputPort.Handle(new PutAssetUsageResponse(new[] { new Error(GlobalVariables.error_assetUsageFailure, "Error updating Asset Usage.") }));
            return false;
        }
    }
}
