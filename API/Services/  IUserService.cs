using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain;
using API.helpers;
using API.models;

namespace API.Services
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }

    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { id = Guid.Parse("536801b8-6200-41a1-8e5e-eee72bad1f1c"), Name = "Yllka", Surname = "Selimi", Email = "yllka.selimi@gmail.com", Password = "Banana", Age = 19,  Role = "admin"},
            new User { id = Guid.Parse("5f12b86e-af0b-4ec2-9ddb-5d8d86a57b6b"), Name = "Ardit", Surname = "Xhaferi", Email = "arditxhaferi2@gmail.com", Password = "Banana", Age = 19, Role = "user"},
            };
        

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticationResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticationResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }


        public User GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.id.Equals(id));
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("role", user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}