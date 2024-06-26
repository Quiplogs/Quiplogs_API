﻿using Api.Presenters;
using Api.Serialization;
using System.Net;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;

namespace Api.UseCases.Auth.Register
{
    public sealed class RegisterPresenter : IOutputPort<RegisterResponse>
    {
        public JsonContentResult ContentResult { get; }

        public RegisterPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(RegisterResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
