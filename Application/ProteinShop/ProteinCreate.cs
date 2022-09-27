using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.ProteinShop
{
    public class ProteinCreate
    {
        public class Command : IRequest
        {
            public Protein Protein { get; set; }
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
                context.Proteins.Add(request.Protein);

                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}