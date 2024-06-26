﻿using System.Linq;
using System.Threading.Tasks;
using Quiplogs.Core.Domain;
using Quiplogs.Core.Domain.Entities;
using Quiplogs.Core.Dto;
using Quiplogs.Core.Dto.Requests.User;
using Quiplogs.Core.Dto.Responses.User;
using Quiplogs.Core.Interfaces;
using Quiplogs.Core.Interfaces.Repositories;
using Quiplogs.Core.Interfaces.UseCases.User;

namespace Quiplogs.Core.UseCases.User
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterRequest message, IOutputPort<RegisterResponse> outputPort)
        {
            // For now we only 3 users to use the system for free
            var userLimit = 3;


            var getUsers = await _userRepository.GetAll(message.CompanyId, null);
            if (getUsers.Success)
            {
                if(getUsers.Users.Count() >= userLimit)
                {
                    outputPort.Handle(new RegisterResponse(new[] { new Error("User Limit", $"You have reached the maximum amount of users for your subscription") }));
                    return false;
                }
            }

            var user = new AppUser
            {
                FirstName = message.FirstName,
                LastName = message.LastName,
                Email = message.Email,
                UserName = message.UserName,
                Role = Role.SuperAdmin,
                CompanyId = message.CompanyId,
                LocationId = null
            };

            var response = await _userRepository.Create(user, message.Password);
            outputPort.Handle(response.Success ? new RegisterResponse(response.Id, true) : new RegisterResponse(response.Errors));
            return response.Success;
        }
    }
}
