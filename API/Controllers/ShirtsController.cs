using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistance;


namespace API.Controllers
{
    public class ShirtsController : BaseAPIController
    {
        private readonly DataContext context;

       public ShirtsController(DataContext context)
       {
            this.context = context;

       }


    }
}


