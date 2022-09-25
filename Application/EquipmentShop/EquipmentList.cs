using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.EquipmentShop
{
    public class EquipmentList
    {
        public class Query : IRequest<List<Equipment>> {
            public Equipment Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Equipment>>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }

            public async Task<List<Equipment>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Equipments.ToListAsync();
            }
        }
    }
}