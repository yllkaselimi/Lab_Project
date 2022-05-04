using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity  { get; set; }
        }

        public class Hanndler : IRequestHandler<Command>
        {
        private readonly DataContext context;
            public Hanndler(DataContext context)
            {
            this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Activity.id);

                activity.Title = request.Activity.Title ?? activity.Title;

                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}