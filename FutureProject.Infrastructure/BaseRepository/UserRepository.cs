using FutureProject.Domain.Entities.Models;
using FutureProject.Infrastructure.Persistance;
using FutureProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureProject.Infrastructure.BaseRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FutureProjectDbContext context) : base(context)
        {
        }
    }
}
