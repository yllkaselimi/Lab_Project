using System;
using Domain;

namespace API.models
{
    public class AuthenticationResponse
    {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int Age { get; set; }
            public string Token { get; set; }

            public AuthenticationResponse(User user, string token)
            {
                Id = user.id;
                Name = user.Name;
                Surname = user.Surname;
                Email = user.Email;
                Password = user.Password;
                Age = user.Age;
                Token = token;
            }
    
    }
}