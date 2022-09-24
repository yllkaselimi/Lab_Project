using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ShirtShop
{
    public class ShirtList
    {
        public class Query : IRequest<List<Shirts>> {
            public Shirts Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Shirts>>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }

            public async Task<List<Shirts>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Shirt.ToListAsync();
            }
        }
    }
}