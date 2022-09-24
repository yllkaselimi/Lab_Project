using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.ShirtShop
{
    public class ShirtDetails
    {
        public class Query : IRequest<Shirts>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Shirts>
        {
        private readonly DataContext context;
            public Handler(DataContext context){

                  this.context = context;
            }
            public async Task<Shirts> Handle(Query request, CancellationToken cancellationToken)
            {
               return await context.Shirt.FindAsync(request.Id);
            }
        }
    }
}