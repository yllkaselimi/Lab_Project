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
    public class ProteinDetails
    {
        public class Query : IRequest<Protein>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Protein>
        {
        private readonly DataContext context;
            public Handler(DataContext context){

                  this.context = context;
            }
            public async Task<Protein> Handle(Query request, CancellationToken cancellationToken)
            {
               return await context.Proteins.FindAsync(request.Id);
            }
        }
    }
}