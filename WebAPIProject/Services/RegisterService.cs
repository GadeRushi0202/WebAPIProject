using WebAPIProject.Models;
using WebAPIProject.Repositories;

namespace WebAPIProject.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepostories repo;
        public RegisterService(IRegisterRepostories repo)
        {
            this.repo = repo;
        }
        public async Task<Register> GetLogin(Register r)
        {
            return await repo.GetLogin(r);
        }

        public async Task<int> Register(Register r)
        {
            return await repo.Register(r);
        }
    }
}
