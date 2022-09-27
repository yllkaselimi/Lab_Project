using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistance;

namespace Application.ProteinShop
{
    public class ProteinDelete
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
                var protein = await context.Proteins.FindAsync(request.Id);

                context.Remove(protein);

                await context.SaveChangesAsync();

                return Unit.Value;


            }
        }
    }
}