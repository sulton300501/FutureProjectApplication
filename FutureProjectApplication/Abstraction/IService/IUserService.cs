using FutureProject.Domain.Entities.DTOs;
using FutureProject.Domain.Entities.Models;
using FutureProject.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FutureProjectApplication.Abstraction.IService
{
    public interface IUserService
    {
        public Task<User> Create(UserDTO userDTO);
        public Task<User> GetByName(string name);

        public Task<User> GetById(int id);
        public Task<User> GetByEmail(string email);
        public Task<User> GetByLogin(string login);
        public Task<IEnumerable<UserViewModel>> GetAll();

        public Task<bool> Delete(Expression<Func<User, bool>> expression);
        public Task<User> Update(int Id , UserDTO userDTO);

    }
}
