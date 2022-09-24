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
    public class EquipmentList
    {
        public class Command : IRequest
        {
            public Equipment Equipment { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Equipments.Add(request.Equipment);

                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}