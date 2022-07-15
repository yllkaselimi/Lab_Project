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

        [HttpGet("/api/activities")]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("/{id}")] // activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});    
        }

        [HttpPost("/api/CreateActivity")]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {

            return Ok(await Mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPut("/api/update/{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity }));
        }

        [HttpDelete("/api/activities/{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}