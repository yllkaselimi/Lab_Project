using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.EquipmentShop
{
    public class EquipmentEdit
    {
        public class Command : IRequest
        {
            public Equipment Equipment  { get; set; }
        }

        public class Hanndler : IRequestHandler<Command>
        {
        private readonly DataContext context;
        private readonly IMapper mapper;
            public Hanndler(DataContext context, IMapper mapper)
            {
            this.mapper = mapper;
            this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var equipment = await context.Equipments.FindAsync(request.Equipment.Id);
             
                mapper.Map(request.Equipment, equipment);

                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}