using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance;

namespace Application.EquipmentShop
{
    public class EquipmentDelete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var equipment = await context.Equipments.FindAsync(request.Id);

                context.Remove(equipment);

                await context.SaveChangesAsync();

                return Unit.Value;


            }
        }
    }
}