using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Persistance;
 using Microsoft.AspNetCore.Mvc;
 using Domain;
 using Microsoft.EntityFrameworkCore;
 using Application.EquipmentShop;
 using MediatR;


 namespace API.Controllers
 {
     public class EquipmentController : BaseAPIController
     {
        [HttpGet("/api/EquipmentList")]
        public async Task<ActionResult<List<Equipment>>> GetEquipment()
        {
            return await Mediator.Send(new EquipmentList.Query());
        }


        [HttpGet("/api/{id}")] // activities/id
        public async Task<ActionResult<Equipment>> GetEquipment(Guid id)
        {
            return await Mediator.Send(new EquipmentDetails.Query{Id = id});    
        }


        [HttpPost("/api/CreateEquipment")]
        public async Task<IActionResult> CreateEquipment(Equipment equipment)
        {

            return Ok(await Mediator.Send(new EquipmentCreate.Command{Equipment = equipment}));
        }

        [HttpPut("/api/EditEquipment/{id}")]
        public async Task<IActionResult> EditEquipment(Guid id, Equipment equipment)
        {
            equipment.Id = id;
            return Ok(await Mediator.Send(new EquipmentEdit.Command{Equipment = equipment }));
        }
        
        [HttpDelete("/api/DeleteEquipment/{id}")]
        public async Task<IActionResult> DeleteEquipment(Guid id)
        {
            return Ok(await Mediator.Send(new EquipmentDelete.Command{Id = id}));
        }
     }
  }