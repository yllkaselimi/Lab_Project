using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistance;
using Application.ShirtShop;


namespace API.Controllers
{
    public class ShirtsController : BaseAPIController
    {
        [HttpGet("/api/ShirtsList")]
        public async Task<ActionResult<List<Shirts>>> GetShirts()
        {
            return await Mediator.Send(new ShirtList.Query());
        }
        [HttpGet("/api/shirtid/{id}")] // activities/id
        public async Task<ActionResult<Shirts>> GetShirt(Guid id)
        {
            return await Mediator.Send(new ShirtDetails.Query{Id = id});    
        }

        [HttpPost("/api/CreateShirt")]
        public async Task<IActionResult> CreateShirts(Shirts shirts)
        {

            return Ok(await Mediator.Send(new ShirtCreate.Command{Shirts = shirts}));
        }

        [HttpPut("/api/EditShirt/{id}")]
        public async Task<IActionResult> EditShirts(Guid id, Shirts shirts)
        {
            shirts.id = id;
            return Ok(await Mediator.Send(new ShirtEdit.Command{Shirts = shirts }));
        }

        [HttpDelete("/api/deleteshirt/{id}")]
        public async Task<IActionResult> DeleteShirt(Guid id)
        {
            return Ok(await Mediator.Send(new ShirtDelete.Command{Id = id}));

        }
         //??

    
}

}
