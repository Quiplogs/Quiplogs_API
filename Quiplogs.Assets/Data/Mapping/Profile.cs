using AutoMapper;
using Quiplogs.Assets.Data.Entities;
using Quiplogs.Assets.Domain.Entities;

namespace Quiplogs.Assets.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Asset, AssetDto>();
            CreateMap<AssetDto, Asset>();
        }
    }
}
