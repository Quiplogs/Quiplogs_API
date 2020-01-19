﻿namespace Api.Core.Domain.Entities
{
    public class AppUser
    {
        public string Id { get; }
        public string FirstName { get;}
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }
        public string PasswordHash { get;}
        public string Role { get;}
        public AppUser(string firstName, string lastName, string email, string userName, string role, string id = null, string passwordHash = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
