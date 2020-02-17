﻿using Api.Core.Dto.Requests.Service;
using Api.Core.Dto.Responses.Service;

namespace Api.Core.Interfaces.UseCases.Service
{
    public interface IRemoveServiceUseCase : IRequestHandler<RemoveServiceRequest, RemoveServiceResponse>
    {
    }
}
