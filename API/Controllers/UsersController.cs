using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.helpers;
using API.models;
using API.Services;
using Application.Users;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseAPIController
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/api/userCreate")]
        public async Task<IActionResult> UserCreate(User user)
        {

            return Ok(await Mediator.Send(new UserCreate.Command{User = user}));
        }



        [HttpGet("/api/GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await Mediator.Send(new UsersList.Query());

        }
        


        [HttpPost("/api/authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}