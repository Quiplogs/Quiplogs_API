using AutoMapper;
using Quiplogs.Assets.Data.Entities;
using Quiplogs.Assets.Domain.Entities;
using Quiplogs.Assets.Dto.Requests.Asset;
using Quiplogs.Assets.Dto.Requests.AssetUsage;

namespace Quiplogs.Assets.Data.Mapping
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDto>();
            CreateMap<AssetDto, Asset>();

            CreateMap<PutAssetRequest, Asset>();
            CreateMap<PutAssetUsageRequest, Asset>();

            CreateMap<AssetUsage, AssetUsageDto>();
            CreateMap<AssetUsageDto, AssetUsage>();
        }
    }
}
