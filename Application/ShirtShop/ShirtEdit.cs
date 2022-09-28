using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.ShirtShop
{
    public class ShirtEdit
    {
        public class Command : IRequest
        {
            public Shirts Shirts { get; set; }
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
                var shirts = await context.Shirt.FindAsync(request.Shirts.id);

                mapper.Map(request.Shirts, shirts);

                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}