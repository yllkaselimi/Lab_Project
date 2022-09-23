using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistance;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    public class EquipmentController : BaseAPIController
    {
        private readonly DataContext context;
        public EquipmentController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equipment>>> GetEquipment() 
        {
        return await this.context.Equipments.ToListAsync();
        }

        [HttpGet("{id}")] //equipments/id
         public async Task<ActionResult<Equipment>> GetEquipment(Guid id)
        {
        return await this.context.Equipments.FindAsync(id);
        }
    } 
 }