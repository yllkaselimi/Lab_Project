using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseAPIController
    {


        [HttpGet("/getAll")]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("/{id}")] // activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});    
        }

        [HttpPost("/CreateActivity")]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {

            return Ok(await Mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPut("/update/{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity }));
        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}