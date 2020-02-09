﻿using Api.Core.Dto.Requests.Equipment;
using Api.Core.Dto.Responses.Equipment;

namespace Api.Core.Interfaces.UseCases.Equipment
{
    public interface IFetchEquipmentUseCase : IRequestHandler<FetchEquipmentRequest, FetchEquipmentResponse>
    {
    }
}
