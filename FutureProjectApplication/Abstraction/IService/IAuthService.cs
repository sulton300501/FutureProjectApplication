using FutureProject.Domain.Entities.DTOs;

namespace FutureProjectApplication.Abstraction.IService
{
    public interface IAuthService
    {
        public Task<ResponseLogin> GenerateToken(RequestLogin user);
    }
}
