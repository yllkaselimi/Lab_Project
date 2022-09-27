using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ProteinShop
{
    public class ProteinList
    {
        public class Query : IRequest<List<Protein>> {
            public Protein Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Protein>>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }

            public async Task<List<Protein>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Proteins.ToListAsync();
            }
        }
    }
}