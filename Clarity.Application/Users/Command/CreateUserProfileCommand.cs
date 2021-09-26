using Clarity.Application.Common.Interaces;
using Clarity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clarity.Application.Users.Command
{
    public class CreateUserProfileCommand : IRequest<User>
    {
        public User User { get; set; }

        public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, User>
        {
            private readonly IMediator _mediator;
            private readonly IClarityDbContext _dbContext;

            public CreateUserProfileCommandHandler(IMediator mediator, IClarityDbContext dbContext)
            {
                _mediator = mediator;
                _dbContext = dbContext;
            }

            public async Task<User> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
            {
                User user = new User
                {
                    UID = Guid.NewGuid(),
                    Name = request.User.Name,
                    Age = request.User.Age,
                    Wallet = new Wallet
                    {
                        UID = Guid.NewGuid()
                    }
                };

                _dbContext.Users.Add(user);

                return user;
            }
        }
    }
}
