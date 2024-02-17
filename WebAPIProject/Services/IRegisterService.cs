using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public interface IRegisterService
    {
        Task<int> Register(Register r);

        Task<Register> GetLogin(Register r);
    }
}
