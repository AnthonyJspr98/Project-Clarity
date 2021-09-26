using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Clarity.Application.Common.Interaces;
using Clarity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clarity.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
        {
            private readonly IClarityDbContext _dbContext;

            public GetAllUsersQueryHandler(IClarityDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return await _dbContext.Users.ToListAsync();
            }
        }
    }
}