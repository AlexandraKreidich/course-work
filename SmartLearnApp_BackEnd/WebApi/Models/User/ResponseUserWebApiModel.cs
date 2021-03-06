﻿using JetBrains.Annotations;

namespace WebApi.Models.User
{
    public class ResponseUserWebApiModel
    {
        public int Id { get;}

        [NotNull]
        public string FirstName { get;}

        [NotNull]
        public string LastName { get;}

        [NotNull]
        public string Email { get;}

        [NotNull]
        public string Token { get;}

        public ResponseUserWebApiModel(
            int id,
            [NotNull] string firstName,
            [NotNull] string lastName,
            [NotNull] string email,
            [NotNull] string token
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Token = token;
        }
    }
}
