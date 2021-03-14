using Ironwood.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ironwood.Application.Common.Interaces
{
    public interface IClarityDbContext
    {
         public DbSet<User> Users { get ; set; }
    }
}