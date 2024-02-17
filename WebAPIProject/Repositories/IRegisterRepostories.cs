using WebAPIProject.Models;

namespace WebAPIProject.Repositories
{
    public interface IRegisterRepostories
    {

        Task<int> Register(Register r);

        Task<Register> GetLogin(Register r);

    }
}
