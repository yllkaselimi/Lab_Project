using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ProteinShop;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProteinController : BaseAPIController
    {

        [HttpGet("/api/ProteinList")]
        public async Task<ActionResult<List<Protein>>> GetAProtein()
        {
            return await Mediator.Send(new ProteinList.Query());
        }
         [HttpGet("/apiid/{id}")] 
        public async Task<ActionResult<Protein>> GetProtein(Guid id)
        {
            return await Mediator.Send(new ProteinDetails.Query{Id = id});    
        }

        [HttpPost("/api/CreateProtein")]
        public async Task<IActionResult> CreateProtein(Protein protein)
        {

            return Ok(await Mediator.Send(new ProteinCreate.Command{Protein = protein}));
        }

        [HttpPut("/api/UpdateProtein/{id}")]
        public async Task<IActionResult> EditProtein(Guid id, Protein protein)
        {
            protein.id = id;
            return Ok(await Mediator.Send(new ProteinEdit.Command{Protein = protein}));
        }
        // 200 OK but update not showing in getAll

        [HttpDelete("/api/DeleteProtein/{id}")]
        public async Task<IActionResult> DeleteProtein(Guid id)
        {
            return Ok(await Mediator.Send(new ProteinDelete.Command{Id = id}));
        }
    }
}
    
