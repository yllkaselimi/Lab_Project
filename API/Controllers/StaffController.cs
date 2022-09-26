using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Persistance;
 using Microsoft.AspNetCore.Mvc;
 using Domain;
 using Microsoft.EntityFrameworkCore;
 using Application.MeetStaff;
 using MediatR;


 namespace API.Controllers
 {
     public class StaffController : BaseAPIController
     {
        [HttpGet("/api/StaffList")]
        public async Task<ActionResult<List<Staff>>> GetStaff()
        {
            return await Mediator.Send(new StaffList.Query());
        }


        [HttpGet("/api/staffid/{id}")] // activities/id
        public async Task<ActionResult<Staff>> GetStaff(Guid id)
        {
            return await Mediator.Send(new StaffDetails.Query{Id = id});    
        }


        [HttpPost("/api/CreateStaff")]
        public async Task<IActionResult> CreateStaff(Staff staff)
        {

            return Ok(await Mediator.Send(new StaffCreate.Command{Staff = staff}));
        }

        [HttpPut("/api/EditStaff/{id}")]
        public async Task<IActionResult> EditStaff(Guid id, Staff staff)
        {
            staff.Id = id;
            return Ok(await Mediator.Send(new StaffEdit.Command{Staff = staff }));
        }
        
        [HttpDelete("/api/DeleteStaff/{id}")]
        public async Task<IActionResult> DeleteStaff(Guid id)
        {
            return Ok(await Mediator.Send(new StaffDelete.Command{Id = id}));
        }
     }
  }