using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ironwood.Domain.Entities;
using MediatR;

namespace Clarity.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
        {
            public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
               
               var _userOne = new User
                {
                    UID = Guid.NewGuid(),
                    Name = "Atong",
                    Age = 21
                };
                var _userTwo = new User
                {
                    UID = Guid.NewGuid(),
                    Name = "Ang",
                    Age = 21
                };

                var _users = new List<User>();

                _users.Add(_userOne);
                _users.Add(_userTwo);
              
              return _users;
            }
        }
    }
}