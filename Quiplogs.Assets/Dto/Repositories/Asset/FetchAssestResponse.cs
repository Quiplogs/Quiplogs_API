using System.Collections.Generic;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Repositories;

namespace Quiplogs.Assets.Dto.Repositories.Asset
{
    public class FetchAssetResponse : BaseRepositoryResponse
    {
        public List<Domain.Entities.Asset> Assets { get; set; }

        public FetchAssetResponse(List<Domain.Entities.Asset> assets, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Assets = assets;
        }
    }
}
