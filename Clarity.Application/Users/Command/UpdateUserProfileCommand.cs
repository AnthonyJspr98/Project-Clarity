
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

namespace Clarity.Application.Users.Command
{
    public class UpdateUserProfileCommand : IRequest<User>
    {
        public User User { get; set; }
        public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, User>
        {
            private readonly IClarityDbContext _dbContext;
            
            public UpdateUserProfileCommandHandler(IClarityDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<User> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
            {
                User userProfile = await _dbContext.Users.Where(a => a.UID == request.User.UID).SingleOrDefaultAsync();

                if (userProfile == null)
                {
                    throw new Exception("Doesnt Exist");
                }

                userProfile.Name = request.User.Name ?? userProfile.Name;
                userProfile.Age = request.User.Age;

                _dbContext.Users.Update(userProfile);

                return userProfile;
            }
        }   
    }
}
