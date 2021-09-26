using Clarity.Application.Common.Interaces;
using Clarity.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clarity.Application.Users.Queries
{
    public class GetUserProfileByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
        public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, User>
        {
            private readonly IClarityDbContext _dbContext;

            public GetUserProfileByIdQueryHandler(IClarityDbContext dbContext)
            {
                _dbContext = dbContext;            
            }
            public async Task<User> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
            {
                return await _dbContext.Users.Where(a => a.UID == request.Id).SingleOrDefaultAsync();
            }
        }

    }
}
