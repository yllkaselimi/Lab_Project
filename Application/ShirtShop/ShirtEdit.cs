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
                // instead of setting each property manually like this
                //activity.Title = request.Activity.Title ?? activity.Title;
                // we use automapper

                mapper.Map(request.Shirts, shirts);

                // so now when we do update our activity we update every field
                // so it wont take a lot of manual writing code

                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}