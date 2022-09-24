using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.EquipmentShop
{
    public class EquipmentDetails
    {
        public class Query : IRequest<Equipment>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Equipment>
        {
        private readonly DataContext context;
            public Handler(DataContext context){

                  this.context = context;
            }
            public async Task<Equipment> Handle(Query request, CancellationToken cancellationToken)
            {
               return await context.Equipments.FindAsync(request.Id);
            }
        }
    }
}