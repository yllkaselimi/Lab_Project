using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistance;

namespace Application.MeetStaff
{
    public class StaffDetails
    {
        public class Query : IRequest<Staff>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Staff>
        {
        private readonly DataContext context;
            public Handler(DataContext context){

                  this.context = context;
            }
            public async Task<Staff> Handle(Query request, CancellationToken cancellationToken)
            {
               return await context.Staffs.FindAsync(request.Id);
            }
        }
    }
}