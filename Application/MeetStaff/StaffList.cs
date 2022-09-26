using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.MeetStaff
{
    public class StaffList
    {
        public class Query : IRequest<List<Staff>> {
            public Staff Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Staff>>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }

            public async Task<List<Staff>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Staffs.ToListAsync();
            }
        }
    }
}