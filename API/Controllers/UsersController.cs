using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Users;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseAPIController
    {

        [HttpPost("/api/userCreate")]
        public async Task<IActionResult> UserCreate(User user)
        {

            return Ok(await Mediator.Send(new UserCreate.Command{User = user}));
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> UserLogIn(User user)
        {
            return Ok(await Mediator.Send(new UserLogIn.Query{User = user}));
        }

    }
}