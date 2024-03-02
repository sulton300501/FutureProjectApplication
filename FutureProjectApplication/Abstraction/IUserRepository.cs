using FutureProject.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjectApplication.Abstraction
{
    public interface IUserRepository:IBaseRepository<User>
    {
    }
}
