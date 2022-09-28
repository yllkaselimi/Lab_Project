using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.ProteinShop
{
    public class ProteinEdit
    {
        public class Command : IRequest
        {
            public Protein Protein { get; set; }
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
                var protein = await context.Proteins.FindAsync(request.Protein.id);

                mapper.Map(request.Protein, protein);

                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}