using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class UserLogIn
    {
        public class Query : IRequest<User>
        {
            public User User { get; set; }
        }

        public class Handler : IRequestHandler<Query, User>
        {
        private readonly DataContext context;
            public Handler(DataContext context){

                  this.context = context;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Users
                    .Where(x => x.Email == request.User.Email)
                    .Where(x => x.Password == request.User.Password)
                    .FirstOrDefaultAsync();  
            }
        }
    }
}