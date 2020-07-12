﻿using Api.Core.Dto;
using Api.Core.Dto.Responses;
using System.Collections.Generic;

namespace Quiplogs.Assets.Dto.Repositories.AssetUsage
{
    public class RemoveAssetUsageResponse : BaseResponse
    {
        public string Description { get; set; }

        public RemoveAssetUsageResponse(string description, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Description = description;
        }
    }
}
