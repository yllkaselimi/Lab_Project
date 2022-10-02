using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Users
{
    public class UsersList
    {
        public class Query : IRequest<List<User>> {
            public User Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<User>>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }

            public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Users.ToListAsync();
            }
        }
    }
}